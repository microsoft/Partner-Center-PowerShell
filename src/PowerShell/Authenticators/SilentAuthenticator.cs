// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Identity.Client;
    using Rest;

    /// <summary>
    /// Provides the ability to authenticate non-interactively.
    /// </summary>
    internal class SilentAuthenticator : DelegatingAuthenticator
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
            IPublicClientApplication app = GetClient(parameters.Account, parameters.Environment).AsPublicClient();

            ServiceClientTracing.Information(string.Format("[SilentAuthenticator] Calling GetAccountsAsync"));
            IEnumerable<IAccount> accounts = await app.GetAccountsAsync().ConfigureAwait(false);

            ServiceClientTracing.Information($"[SilentAuthenticator] Calling AcquireTokenSilent - Scopes: '{string.Join(",", parameters.Scopes)}', UserId: '{((SilentParameters)parameters).UserId}', Number of accounts: '{accounts.Count()}'");
            AuthenticationResult authResult = await app.AcquireTokenSilent(
                parameters.Scopes,
                accounts.FirstOrDefault(a => a.HomeAccountId.ObjectId.Equals(((SilentParameters)parameters).UserId)))
                .ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);

            return authResult;
        }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is SilentParameters;
        }
    }
}