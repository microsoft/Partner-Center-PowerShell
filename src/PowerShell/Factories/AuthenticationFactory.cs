// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Authenticators;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;

    /// <summary>
    /// Factory used to perform authentication operations.
    /// </summary>
    internal class AuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// The authenticator builder used to chain authenticators.
        /// </summary>
        private static IAuthenticatorBuilder Builder => new DefaultAuthenticatorBuilder();

        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="account">The account information to be used when generating the client.</param>
        /// <param name="environment">The environment where the client is connecting.</param>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="message">The message to be written to the console.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result from the authentication request.</returns>
        public async Task<AuthenticationResult> AuthenticateAsync(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes, string message = null, CancellationToken cancellationToken = default)
        {
            AuthenticationResult authResult = null;
            IAuthenticator processAuthenticator = Builder.Authenticator;

            while (processAuthenticator != null && authResult == null)
            {
                authResult = await processAuthenticator.TryAuthenticateAsync(GetAuthenticationParameters(account, environment, scopes, message), cancellationToken).ConfigureAwait(false);

                if (authResult != null)
                {
                    if (authResult.Account?.HomeAccountId != null)
                    {
                        account.Identifier = authResult.Account.HomeAccountId.Identifier;
                        account.ObjectId = authResult.Account.HomeAccountId.ObjectId;
                    }

                    if (account.Tenant.Equals("organizations", StringComparison.InvariantCultureIgnoreCase) && !string.IsNullOrEmpty(authResult.TenantId))
                    {
                        account.Tenant = authResult.TenantId;
                    }

                    break;
                }

                processAuthenticator = processAuthenticator.NextAuthenticator;
            }

            return authResult;
        }

        /// <summary>
        /// Gets the parameters used to perform authentication..
        /// </summary>
        /// <param name="account">The account information to be used when generating the client.</param>
        /// <param name="environment">The environment where the client is connecting.</param>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="message">The message to be written to the console.</param>
        /// <returns>The parameters used to perform authentication.</returns>
        private AuthenticationParameters GetAuthenticationParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes, string message = null)
        {
            if (account.IsPropertySet(PartnerAccountPropertyType.AccessToken))
            {
                return new AccessTokenParameters(account, environment, scopes);
            }
            else if (account.IsPropertySet("UseAuthCode"))
            {
                return new InteractiveParameters(account, environment, scopes, message);
            }
            else if (account.IsPropertySet(PartnerAccountPropertyType.RefreshToken))
            {
                return new RefreshTokenParameters(account, environment, scopes);
            }
            else if (account.Type == AccountType.User)
            {
                if (!string.IsNullOrEmpty(account.ObjectId))
                {
                    return new SilentParameters(account, environment, scopes);
                }
                else if (account.IsPropertySet("UseDeviceAuth"))
                {
                    return new DeviceCodeParameters(account, environment, scopes);
                }

                return new InteractiveParameters(account, environment, scopes, message);
            }
            else if (account.Type == AccountType.Certificate || account.Type == AccountType.ServicePrincipal)
            {
                return new ServicePrincipalParameters(account, environment, scopes);
            }

            return null;
        }
    }
}