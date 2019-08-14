﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using Authentication;
    using IdentityModel.Clients.ActiveDirectory;
    using Properties;

    /// <summary>
    /// Factory used to perform authentication operations.
    /// </summary>
    public class AuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationFactory" /> class.
        /// </summary>
        public AuthenticationFactory()
        {
            LoggerCallbackHandler.UseDefaultLogging = false;
        }

        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <param name="promptAction">The action to prompt the user for input.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationToken Authenticate(PartnerContext context, Action<string> debugAction, Action<string> promptAction = null)
        {
            AuthenticationContext authContext;
            AuthenticationResult authResult;
            Claim claim;
            DateTimeOffset expiration;
            JwtSecurityToken token;
            JwtSecurityTokenHandler tokenHandler;
            PartnerEnvironment environment;

            environment = PartnerEnvironment.PublicEnvironments[context.Environment];

            authContext = new AuthenticationContext(
                $"{environment.ActiveDirectoryAuthority}{context.Account.Properties[AzureAccountPropertyType.Tenant]}");

            if (context.Account.Type == AccountType.AccessToken)
            {
                tokenHandler = new JwtSecurityTokenHandler();
                token = tokenHandler.ReadJwtToken(context.Account.Properties[AzureAccountPropertyType.AccessToken]);

                claim = token.Claims.SingleOrDefault(c => c.Type.Equals("oid", StringComparison.InvariantCultureIgnoreCase));
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = claim?.Value;

                claim = token.Claims.SingleOrDefault(c => c.Type.Equals("tid", StringComparison.InvariantCultureIgnoreCase));
                context.Account.Properties[AzureAccountPropertyType.Tenant] = claim?.Value;

                claim = token.Claims.SingleOrDefault(c => c.Type.Equals("exp", StringComparison.InvariantCultureIgnoreCase));
                expiration = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(claim.Value, CultureInfo.InvariantCulture));

                claim = token.Claims.SingleOrDefault(c => c.Type.Equals("unique_name", StringComparison.InvariantCultureIgnoreCase));

                context.AuthenticationType = claim == null ? AuthenticationTypes.AppOnly : AuthenticationTypes.AppPlusUser;

                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateAccessTokenTrace,
                        expiration.ToString(CultureInfo.CurrentCulture),
                        context.Account.Properties[AzureAccountPropertyType.Tenant],
                        context.Account.Properties[AzureAccountPropertyType.UserIdentifier],
                        claim?.Value));

                return new AuthenticationToken(
                    context.Account.Properties[AzureAccountPropertyType.AccessToken],
                    expiration);
            }
            else if (context.Account.Type == AccountType.ServicePrincipal)
            {
                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateServicePrincipalTrace,
                        environment.ActiveDirectoryAuthority,
                        context.Account.Id,
                        environment.AzureAdGraphEndpoint,
                        context.Account.Properties[AzureAccountPropertyType.Tenant]));

                authResult = authContext.AcquireTokenAsync(
                    environment.AzureAdGraphEndpoint,
                    new ClientCredential(
                        context.Account.Id,
                        context.Account.Properties[AzureAccountPropertyType.ServicePrincipalSecret])).ConfigureAwait(false).GetAwaiter().GetResult();

                context.AuthenticationType = Authentication.AuthenticationTypes.AppOnly;
            }
            else if (!context.Account.Properties.ContainsKey(AzureAccountPropertyType.UserIdentifier))
            {
#if NETSTANDARD
                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateDeviceCodeTrace,
                        context.ApplicationId,
                        environment.PartnerCenterEndpoint));

                DeviceCodeResult deviceCodeResult = authContext.AcquireDeviceCodeAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId).ConfigureAwait(false).GetAwaiter().GetResult();

                promptAction(deviceCodeResult.Message);

                authResult = authContext.AcquireTokenByDeviceCodeAsync(deviceCodeResult).ConfigureAwait(false).GetAwaiter().GetResult();
#else
                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateAuthorizationCodeTrace,
                        context.ApplicationId,
                        environment.ActiveDirectoryAuthority,
                        AuthenticationConstants.RedirectUriValue,
                        environment.PartnerCenterEndpoint));

                authResult = authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    new Uri(AuthenticationConstants.RedirectUriValue),
                    new PlatformParameters(PromptBehavior.Always),
                    UserIdentifier.AnyUser).ConfigureAwait(false).GetAwaiter().GetResult();
#endif

                context.Account.Id = authResult.UserInfo.DisplayableId;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.UserInfo.UniqueId;
                context.AuthenticationType = Authentication.AuthenticationTypes.AppPlusUser;
            }
            else
            {
                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateSilentTrace,
                        context.ApplicationId,
                        environment.ActiveDirectoryAuthority,
                        environment.PartnerCenterEndpoint,
                        context.Account.Id));

                authResult = authContext.AcquireTokenSilentAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    new UserIdentifier(context.Account.Id, UserIdentifierType.RequiredDisplayableId)).ConfigureAwait(false).GetAwaiter().GetResult();

                context.Account.Id = authResult.UserInfo.DisplayableId;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.UserInfo.UniqueId;
                context.AuthenticationType = Authentication.AuthenticationTypes.AppPlusUser;
            }

            return new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }
    }
}