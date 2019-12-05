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
        internal IAuthenticatorBuilder Builder => new DefaultAuthenticatorBuilder();

        public async Task<AuthenticationResult> AuthenticateAsync(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes, string message = null, CancellationToken cancellationToken = default)
        {
            AuthenticationResult authResult = null;
            IAuthenticator processAuthenticator = Builder.Authenticator;

            while (processAuthenticator != null && authResult == null)
            {
                authResult = await processAuthenticator.TryAuthenticateAsync(GetAuthenticationParameters(account, environment, scopes, message), cancellationToken);

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

                processAuthenticator = processAuthenticator.Next;
            }

            return authResult;
        }

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
            else if (account.Type == AccountType.ServicePrincipal || account.Type == AccountType.Certificate)
            {
                return new ServicePrincipalParameters(account, environment, scopes);
            }

            return null;
        }
    }
}