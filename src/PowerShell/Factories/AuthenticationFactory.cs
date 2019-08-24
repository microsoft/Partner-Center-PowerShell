// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using Authenticators;
    using Extensions;
    using Microsoft.Identity.Client;
    using Models.Authentication;

    /// <summary>
    /// Factory used to perform authentication operations.
    /// </summary>
    internal class AuthenticationFactory : IAuthenticationFactory
    {
        internal IAuthenticatorBuilder Builder => new DefaultAuthenticatorBuilder();

        public AuthenticationToken Authenticate(PartnerAccount account, PartnerEnvironment environment, string resourceId, string tenantId)
        {
            AuthenticationResult authResult = null;
            IAuthenticator processAuthenticator = Builder.Authenticator;
            int retries = 5;

            while (retries-- > 0)
            {
                try
                {
                    while (processAuthenticator != null && processAuthenticator.TryAuthenticate(GetAuthenticationParameters(account, environment, resourceId, tenantId), out authResult))
                    {
                        if (authResult != null)
                        {
                            account.Id = authResult.Account.HomeAccountId.ObjectId;
                            account.SetProperty(PartnerAccountPropertyType.Tenant, authResult.TenantId);
                            break;
                        }

                        processAuthenticator = processAuthenticator.Next;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }

                break;
            }

            return (authResult == null) ? null : new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }

        private AuthenticationParameters GetAuthenticationParameters(PartnerAccount account, PartnerEnvironment environment, string resourceId, string tenantId)
        {
            if (account.Type == AccountType.User)
            {
                if (!string.IsNullOrEmpty(account.Id))
                {
                    return new SilentParameters(environment, resourceId, tenantId, account.Id);
                }
                else if (account.IsPropertySet("UseDeviceAuth"))
                {
                    return new DeviceCodeParameters(environment, resourceId, tenantId);
                }

                return new InteractiveParameters(environment, resourceId, tenantId);

            }
            else if (account.Type == AccountType.ServicePrincipal ||
                     account.Type == AccountType.Certificate)
            {
                return new ServicePrincipalParameters(
                    environment, 
                    tenantId, 
                    resourceId, 
                    account.Id, 
                    account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint),
                    null);
            }

            return null;
        }

    }
}