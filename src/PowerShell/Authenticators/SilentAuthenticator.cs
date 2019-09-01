// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Identity.Client;

    /// <summary>
    /// Provides the ability to authenticate non-interactively.
    /// </summary>
    internal class SilentAuthenticator : DelegatingAuthenticator
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
            IPublicClientApplication app = GetClient(parameters.Account, parameters.Environment).AsPublicClient();

            IEnumerable<IAccount> accounts = app.GetAccountsAsync().ConfigureAwait(false).GetAwaiter().GetResult();

            AuthenticationResult authResult = app.AcquireTokenSilent(
                parameters.Scopes,
                accounts.FirstOrDefault(a => a.HomeAccountId.ObjectId.Equals(((SilentParameters)parameters).UserId)))
                .ExecuteAsync()
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

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