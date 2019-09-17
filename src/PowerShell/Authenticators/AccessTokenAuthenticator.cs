// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Threading.Tasks;
    using Identity.Client;
    using IdentityModel.JsonWebTokens;
    using PartnerCenter.Exceptions;

    /// <summary>
    /// Provides the ability to authenticate using an access token.
    /// </summary>
    internal class AccessTokenAuthenticator : DelegatingAuthenticator
    {
        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public override async Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters)
        {
            AccessTokenParameters accessTokenParameters = parameters as AccessTokenParameters;
            JsonWebToken jwt = new JsonWebToken(accessTokenParameters.AccessToken);

            if (DateTimeOffset.UtcNow > jwt.ValidTo)
            {
                throw new PartnerException("The access token has expired. Generate a new one and try again.");
            }

            await Task.CompletedTask;

            return new AuthenticationResult(
                accessTokenParameters.AccessToken,
                false,
                null,
                jwt.ValidTo,
                jwt.ValidTo,
                parameters.Account.Tenant,
                null,
                null,
                parameters.Scopes);
        }

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public override bool CanAuthenticate(AuthenticationParameters parameters)
        {
            return parameters is AccessTokenParameters;
        }
    }
}