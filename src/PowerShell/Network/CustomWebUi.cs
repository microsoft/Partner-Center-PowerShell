// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Identity.Client.Extensibility;
    using Models;
    using Models.Authentication;

    /// <summary>
    /// Provide a custom Web UI for public client applications to sign-in users and have them consent part of the Authorization code flow.
    /// </summary>
    public class CustomWebUi : ICustomWebUi
    {
        /// <summary>
        /// The HTML returned after successful authentication.
        /// </summary>
        private const string CloseWindowSuccessHtml = @"<html>
  <head><title>Authentication Complete</title></head>
  <body>
    Authentication complete. You can return to the application. Feel free to close this browser tab.
  </body>
</html>";

        /// <summary>
        /// The message written to the console.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomWebUi" /> class.
        /// </summary>
        public CustomWebUi()
        {
            message = "We have launched a browser for you to login. For the old experience with device code flow, please run 'Connect-PartnerCenter -UseDeviceAuthentication'.";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomWebUi" /> class.
        /// </summary>
        /// <param name="message">The message written to the console.</param>
        public CustomWebUi(string message)
        {
            message.AssertNotEmpty(nameof(message));

            this.message = message;
        }

        /// <summary>
        /// Method called by MSAL.NET to delegate the authentication code Web with the Secure Token Service (STS).
        /// </summary>
        /// <param name="authorizationUri">URI computed by MSAL.NET that will let the UI extension navigate to the STS authorization endpoint in order to sign-in the user and have them consent.</param>
        /// <param name="redirectUri">The redirect Uri that was configured. The auth code will be appended to this redirect URI and the browser will redirect to it.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The URI returned back from the STS authorization endpoint. This URI contains a code=CODE parameter that MSAL.NET will extract and redeem.</returns>
        public async Task<Uri> AcquireAuthorizationCodeAsync(Uri authorizationUri, Uri redirectUri, CancellationToken cancellationToken)
        {
            WriteWarning("Attempting to launch a browser for authorization code login.");

            if (!OpenBrowser(authorizationUri.ToString()))
            {
                WriteWarning("Unable to launch a browser for authorization code login. Reverting to device code login.");
            }

            WriteWarning(message);

            TcpListener listener = new TcpListener(IPAddress.Loopback, redirectUri.Port);
            listener.Start();

            using (TcpClient client = await listener.AcceptTcpClientAsync().ConfigureAwait(false))
            {
                string httpRequest = await GetTcpResponseAsync(client.GetStream(), cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();

                string uri = ExtractUriFromHttpRequest(httpRequest, redirectUri.Port);
                await WriteResponseAsync(client.GetStream(), cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();

                return await Task.Run(() => { return new Uri(uri); });
            }
        }

        /// <summary>
        /// Extracts the URI from the HTTP request. 
        /// </summary>
        /// <param name="httpRequest">The HTTP request to be parsed</param>
        /// <param name="port">The port number of the request.</param>
        /// <returns>A URI that contains a code=CODE parameter, which will be used by MSAL.NET to extract and redeem.</returns>
        private string ExtractUriFromHttpRequest(string httpRequest, int port)
        {
            Regex r1 = new Regex(@"GET \/\?(.*) HTTP");
            Match match = r1.Match(httpRequest);
            string getQuery;

            if (!match.Success)
            {
                throw new InvalidOperationException("Not a GET query");
            }

            getQuery = match.Groups[1].Value;

            UriBuilder uriBuilder = new UriBuilder
            {
                Query = getQuery,
                Port = port
            };

            return uriBuilder.ToString();
        }

        /// <summary>
        /// Reads the response from the TCP operation. 
        /// </summary>
        /// <param name="stream">The <see cref="NetworkStream" /> used to send and receive data.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the TCP operation.</returns>
        private static async Task<string> GetTcpResponseAsync(NetworkStream stream, CancellationToken cancellationToken)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] readBuffer = new byte[1024];
            int numberOfBytesRead;

            do
            {
                numberOfBytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length, cancellationToken).ConfigureAwait(false);

                string s = Encoding.ASCII.GetString(readBuffer, 0, numberOfBytesRead);
                stringBuilder.Append(s);
            }
            while (stream.DataAvailable);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Opens a browser and navigates to the specified URL.
        /// </summary>
        /// <param name="url">The authorization end point used to authenticate the user and have them consent.</param>
        /// <returns><c>true</c> if the browser was successfully opened; otherwise, <c>false</c>.</returns>
        /// <remarks>There is no universal call in .NET Core to open browser See https://github.com/dotnet/corefx/issues/10361 for more details.</remarks>
        private bool OpenBrowser(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw new PlatformNotSupportedException(RuntimeInformation.OSDescription);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Writes the response to the <see cref="NetworkStream" />. 
        /// </summary>
        /// <param name="stream">The <see cref="NetworkStream" /> used to send and receive data.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of the <see cref="Task" /> class that represents the asynchronous operation.</returns>
        private async Task WriteResponseAsync(NetworkStream stream, CancellationToken cancellationToken)
        {
            string fullResponse = $"HTTP/1.1 200 OK\r\n\r\n{CloseWindowSuccessHtml}";
            byte[] response = Encoding.ASCII.GetBytes(fullResponse);

            await stream.WriteAsync(response, 0, response.Length, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="message">The message that describes the warning.</param>
        private void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent("WriteWarning", out EventHandler<StreamEventArgs> writeEvent))
            {
                writeEvent(this, new StreamEventArgs() { Message = message });
            }
        }
    }
}