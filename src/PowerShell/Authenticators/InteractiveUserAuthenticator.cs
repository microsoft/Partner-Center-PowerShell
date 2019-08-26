// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Web;
    using Factories;
    using Identity.Client;
    using Identity.Client.Extensibility;
    using Network;

    /// <summary>
    /// Provides the ability to authenticate using an interactive interface.
    /// </summary>
    internal class InteractiveUserAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override AuthenticationResult Authenticate(AuthenticationParameters parameters)
        {
            AuthenticationResult authResult;
            InteractiveParameters interactiveParameters;
            TcpListener listener = null;
            string replyUrl = string.Empty;

            int port = 8399;

            while (++port < 9000)
            {
                try
                {
                    listener = new TcpListener(IPAddress.Loopback, port);
                    listener.Start();
                    replyUrl = string.Format("http://localhost:{0}/", port);
                    listener.Stop();
                    break;
                }
                catch (Exception ex)
                {
                    WriteWarning(string.Format("Port {0} is taken with exception '{1}'; trying to connect to the next port.", port, ex.Message));
                    listener?.Stop();
                }
            }

            interactiveParameters = (InteractiveParameters)parameters;

            if (string.IsNullOrEmpty(interactiveParameters.Secret))
            {
                IPublicClientApplication app = SharedTokenCacheClientFactory.CreatePublicClient(
                    $"{parameters.Environment.ActiveDirectoryAuthority}{parameters.TenantId}",
                    parameters.ApplicationId,
                    replyUrl,
                    parameters.TenantId);

                authResult = app.AcquireTokenInteractive(parameters.Scopes)
                    .WithCustomWebUi(new CustomWebUi())
                    .WithPrompt(Prompt.ForceLogin)
                    .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }
            else
            {
                IConfidentialClientApplication app = SharedTokenCacheClientFactory.CreateConfidentialClient(
                    $"{parameters.Environment.ActiveDirectoryAuthority}{parameters.TenantId}",
                    parameters.ApplicationId,
                    interactiveParameters.Secret,
                    null,
                    replyUrl,
                    parameters.TenantId);

                ICustomWebUi customWebUi = new CustomWebUi();

                Uri authCodeUrl = customWebUi.AcquireAuthorizationCodeAsync(
                    app.GetAuthorizationRequestUrl(parameters.Scopes).ExecuteAsync(CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult(),
                    new Uri(replyUrl),
                    CancellationToken.None).ConfigureAwait(false).GetAwaiter().GetResult();

                NameValueCollection queryStringParameters = HttpUtility.ParseQueryString(authCodeUrl.Query);

                authResult = app.AcquireTokenByAuthorizationCode(
                    parameters.Scopes,
                    queryStringParameters["code"]).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
            }

            return authResult;
        }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is InteractiveParameters;
        }

        /// <summary>
        /// Writes a warning message to the console.
        /// </summary>
        /// <param name="message">The message that describes the warning.</param>
        private void WriteWarning(string message)
        {
            Console.WriteLine(message);
        }
    }
}