// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using Extensions;
    using Identity.Client;

    /// <summary>
    /// Provides the ability to authenticate using a service principal.
    /// </summary>
    internal class ServicePrincipalAuthenticator : DelegatingAuthenticator
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
            IConfidentialClientApplication app = GetClient(parameters.Account, parameters.Environment).AsConfidentialClient();

            return app.AcquireTokenForClient(parameters.Scopes).ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is ServicePrincipalParameters;
        }
    }
}