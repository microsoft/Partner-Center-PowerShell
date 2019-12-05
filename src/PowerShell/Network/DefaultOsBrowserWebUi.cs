// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Extensions;
    using Identity.Client.Extensibility;
    using Microsoft.Store.PartnerCenter.PowerShell.Models;
    using Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication;

    /// <summary>
    /// Provide a custom Web UI for public client applications to sign-in users and have them consent part of the Authorization code flow.
    /// </summary>
    internal class DefaultOsBrowserWebUi : ICustomWebUi
    {
        /// <summary>
        /// The HTML returned after failed authentication.
        /// </summary>
        private const string CloseWindowFailureHtml = @"<html>
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
        /// Initializes a new instance of the <see cref="DefaultOsBrowserWebUi" /> class.
        /// </summary>
        /// <param name="message">The message written to the console.</param>
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

            using (SingleMessageTcpListener listener = new SingleMessageTcpListener(redirectUri.Port))
            {
                Uri authCodeUri = null;

                await listener.ListenToSingleRequestAndRespondAsync(
                    (uri) =>
                    {
                        authCodeUri = uri;
                        return GetMessageToShowInBroswerAfterAuth(uri);
                    },
                    cancellationToken).ConfigureAwait(false);

                return authCodeUri;
            }
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
        /// Gets the HTML that will be shown in the browser.
        /// </summary>
        /// <param name="uri">The URI returned back from the STS authorization endpoint.</param>
        /// <returns>The HTML to be shown in the browser.</returns>
        private static string GetMessageToShowInBroswerAfterAuth(Uri uri)
        {
            NameValueCollection authCodeQueryKeyValue = HttpUtility.ParseQueryString(uri.Query);

            string errorString = authCodeQueryKeyValue.Get("error");

            if (!string.IsNullOrEmpty(errorString))
            {
                return string.Format(
                    CultureInfo.InvariantCulture,
                    CloseWindowFailureHtml,
                    errorString,
                    authCodeQueryKeyValue.Get("error_description"));
            }

            return CloseWindowSuccessHtml;
        }

        private void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent("WriteWarning", out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs { Resource = message });
            }
        }
    }
}