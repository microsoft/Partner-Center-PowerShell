﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Collections.Specialized;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Extensions;
    using Identity.Client;
    using Identity.Client.Extensibility;
    using Models;
    using Models.Authentication;
    using Network;
    using Rest;

    /// <summary>
    /// Provides the ability to authenticate using an interactive interface.
    /// </summary>
    internal class InteractiveUserAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override async Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default)
        {
            AuthenticationResult authResult;
            IClientApplicationBase app;
            InteractiveParameters interactiveParameters = parameters as InteractiveParameters;
            TcpListener listener = null;
            string redirectUri = null;
            int port = 8399;

            while (++port < 9000)
            {
                try
                {
                    listener = new TcpListener(IPAddress.Loopback, port);
                    listener.Start();
                    redirectUri = string.Format("http://localhost:{0}/", port);
                    listener.Stop();
                    break;
                }
                catch (Exception ex)
                {
                    WriteWarning($"Port {port} is taken with exception '{ex.Message}'; trying to connect to the next port.");
                    listener?.Stop();
                }
            }

            app = await GetClientAsync(parameters.Account, parameters.Environment, redirectUri).ConfigureAwait(false);

            if (app is IConfidentialClientApplication)
            {
                ICustomWebUi customWebUi = new DefaultOsBrowserWebUi(interactiveParameters.Message);

                ServiceClientTracing.Information($"[InteractiveUserAuthenticator] Calling AcquireAuthorizationCodeAsync - Scopes: '{string.Join(",", parameters.Scopes)}'");

                Uri authCodeUrl = await customWebUi.AcquireAuthorizationCodeAsync(
                    await app.AsConfidentialClient().GetAuthorizationRequestUrl(parameters.Scopes).ExecuteAsync(cancellationToken).ConfigureAwait(false),
                    new Uri(redirectUri),
                    cancellationToken).ConfigureAwait(false);

                NameValueCollection queryStringParameters = HttpUtility.ParseQueryString(authCodeUrl.Query);

                ServiceClientTracing.Information($"[InteractiveUserAuthenticator] Calling AcquireTokenByAuthorizationCode - Scopes: '{string.Join(",", parameters.Scopes)}'");

                authResult = await app.AsConfidentialClient().AcquireTokenByAuthorizationCode(
                    parameters.Scopes,
                    queryStringParameters["code"]).ExecuteAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                ServiceClientTracing.Information(string.Format("[InteractiveUserAuthenticator] Calling AcquireTokenInteractive - Scopes: '{0}'", string.Join(",", parameters.Scopes)));

                authResult = await app.AsPublicClient().AcquireTokenInteractive(parameters.Scopes)
                    .WithCustomWebUi(new DefaultOsBrowserWebUi(interactiveParameters.Message))
                    .WithPrompt(Prompt.ForceLogin)
                    .ExecuteAsync(cancellationToken).ConfigureAwait(false);
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

        private void WriteWarning(string message)
        {
            if (PartnerSession.Instance.TryGetComponent("WriteWarning", out EventHandler<StreamEventArgs> writeWarningEvent))
            {
                writeWarningEvent(this, new StreamEventArgs { Resource = message });
            }
        }
    }
}