// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Globalization;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Extensions;
    using Identity.Client.Extensibility;
    using Models;
    using Models.Authentication;

    /// <summary>
    /// Provide a custom Web UI for client applications to sign-in users and have them consent part of the authorization code flow.
    /// </summary>
    public class DefaultOsBrowserWebUi : ICustomWebUi
    {
        /// <summary>
        /// The HTML returned after failed authentication.
        /// </summary>
        private const string DefaultFailureHtml = @"<html>
  <head><title>Authentication Failed</title></head>
  <body>
    Authentication failed. You can return to the application. Feel free to close this browser tab.
</br></br></br></br>
    Error details: error {0} error_description: {1}
  </body>
</html>";

        /// <summary>
        /// The HTML returned after successful authentication.
        /// </summary>
        private const string DefaultSuccessHtml = @"<html>
  <head><title>Authentication Complete</title></head>
  <body>
    Authentication complete. You can return to the application. Feel free to close this browser tab.
  </body>
</html>";

        /// <summary>
        /// The message to be written to the console.
        /// </summary>
        private readonly string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultOsBrowserWebUi" /> class.
        /// </summary>
        /// <param name="message">The message to be written to the console.</param>
        public DefaultOsBrowserWebUi(string message)
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

            return await new HttpListenerInterceptor().ListenToSingleRequestAndRespondAsync(
                redirectUri.Port,
                GetResponseMessage,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the response message to be sent to the browser.
        /// </summary>
        /// <param name="authCodeUri">The URI that contains the authorization code.</param>
        /// <returns>The response message to be sent to the browser.</returns>
        private MessageAndHttpCode GetResponseMessage(Uri authCodeUri)
        {
            // Parse the URI to understand if an error was returned. This is done just to show the user a nice error message in the browser.
            NameValueCollection authCodeQueryKeyValue = HttpUtility.ParseQueryString(authCodeUri.Query);

            string errorValue = authCodeQueryKeyValue.Get("error");

            if (!string.IsNullOrEmpty(errorValue))
            {
                string errorDescription = authCodeQueryKeyValue.Get("error_description");

                WriteWarning($"Default OS browser intercepted an URI with an error: {errorValue} {errorDescription}");

                string errorMessage = string.Format(
                        CultureInfo.InvariantCulture,
                        DefaultFailureHtml,
                        errorValue,
                        errorDescription);

                return new MessageAndHttpCode(HttpStatusCode.OK, errorMessage);
            }

            return new MessageAndHttpCode(HttpStatusCode.OK, DefaultSuccessHtml);
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
        /// Writes the warning message to the pipeline.
        /// </summary>
        /// <param name="text">The message to be written to the pipeline.</param>
        private void WriteWarning(string message)
        {
            message.AssertNotEmpty(nameof(message));

            if (PartnerSession.Instance.TryGetComponent(ComponentKey.WriteWarning, out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs { Resource = message });
            }
        }
    }
}