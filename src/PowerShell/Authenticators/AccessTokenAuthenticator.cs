// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using Exceptions;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;

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
        public override AuthenticationResult Authenticate(AuthenticationParameters parameters)
        {
            AccessTokenParameters accessTokenParameters = parameters as AccessTokenParameters;

            JwtSecurityToken token;
            JwtSecurityTokenHandler tokenHandler;
            System.Security.Claims.Claim claim;

            tokenHandler = new JwtSecurityTokenHandler();
            token = tokenHandler.ReadJwtToken(accessTokenParameters.AccessToken);

            claim = token.Claims.SingleOrDefault(c => c.Type.Equals("exp", StringComparison.InvariantCultureIgnoreCase));
            DateTimeOffset expiration = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(claim.Value, CultureInfo.InvariantCulture));

            if (DateTimeOffset.UtcNow > expiration.UtcDateTime)
            {
                throw new PartnerPSException("Your access token has expired. Please generate a new access token and re-connect.");
            }

            return new AuthenticationResult(
                accessTokenParameters.AccessToken,
                false,
                null,
                expiration,
                expiration,
                parameters.Account.GetProperty(PartnerAccountPropertyType.Tenant),
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