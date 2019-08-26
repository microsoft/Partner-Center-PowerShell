// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Collections.Generic;
    using Authenticators;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;

    /// <summary>
    /// Factory used to perform authentication operations.
    /// </summary>
    internal class AuthenticationFactory : IAuthenticationFactory
    {
        private const string ApplicationId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        internal IAuthenticatorBuilder Builder => new DefaultAuthenticatorBuilder();

        public AuthenticationResult Authenticate(PartnerAccount account, PartnerEnvironment environment, string secret, IEnumerable<string> scopes, string tenantId)
        {
            AuthenticationResult authResult = null;
            IAuthenticator processAuthenticator = Builder.Authenticator;
            int retries = 5;

            while (retries-- > 0)
            {
                try
                {
                    while (processAuthenticator != null && processAuthenticator.TryAuthenticate(GetAuthenticationParameters(account, environment, secret, scopes, tenantId), out authResult))
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

            return authResult ?? null;
        }

        private AuthenticationParameters GetAuthenticationParameters(PartnerAccount account, PartnerEnvironment environment, string secret, IEnumerable<string> scopes, string tenantId)
        {
            if (account.IsPropertySet("UseAuthCode"))
            {
                return new InteractiveParameters(
                    account.Id,
                    environment,
                    secret,
                    scopes,
                    tenantId,
                    account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint));
            }
            else if (account.IsPropertySet(PartnerAccountPropertyType.RefreshToken))
            {
                return new RefreshTokenParameters(
                    account.Id,
                    environment,
                    account.GetProperty(PartnerAccountPropertyType.RefreshToken),
                    secret,
                    scopes,
                    tenantId,
                    account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint));
            }
            else if (account.Type == AccountType.User)
            {
                if (!string.IsNullOrEmpty(account.Id))
                {
                    return new SilentParameters(ApplicationId, environment, scopes, tenantId, account.Id);
                }
                else if (account.IsPropertySet("UseDeviceAuth"))
                {
                    return new DeviceCodeParameters(ApplicationId, environment, scopes, tenantId);
                }

                return new InteractiveParameters(ApplicationId, environment, null, scopes, tenantId, null);
            }
            else if (account.Type == AccountType.ServicePrincipal ||
                     account.Type == AccountType.Certificate)
            {
                return new ServicePrincipalParameters(
                    account.Id,
                    environment,
                    secret,
                    scopes,
                    tenantId,
                    account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint));
            }

            return null;
        }
    }
}