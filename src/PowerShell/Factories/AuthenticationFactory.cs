// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;
    using Authentication;
    using Identity.Client;
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
        }

        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationToken Authenticate(PartnerContext context, Action<string> debugAction)
        {
            AuthenticationResult authResult;
            System.Security.Claims.Claim claim;
            DateTimeOffset expiration;
            JwtSecurityToken token;
            JwtSecurityTokenHandler tokenHandler;
            PartnerEnvironment environment;

            environment = PartnerEnvironment.PublicEnvironments[context.Environment];

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

                IConfidentialClientApplication app = ConfidentialClientApplicationBuilder.Create(context.ApplicationId)
                    .WithClientSecret(context.Account.Properties[AzureAccountPropertyType.ServicePrincipalSecret])
                    .WithTenantId(context.Account.Properties[AzureAccountPropertyType.Tenant])
                    .Build();

                authResult = app.AcquireTokenForClient(new string[] { $"{environment.AzureAdGraphEndpoint}/.default" })
                    .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                context.AuthenticationType = AuthenticationTypes.AppOnly;
            }
            else if (!context.Account.Properties.ContainsKey(AzureAccountPropertyType.UserIdentifier))
            {
                debugAction(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.AuthenticateAuthorizationCodeTrace,
                        context.ApplicationId,
                        environment.ActiveDirectoryAuthority,
                        AuthenticationConstants.RedirectUriValue,
                        environment.PartnerCenterEndpoint));

                IPublicClientApplication app = PublicClientApplicationBuilder.Create(context.ApplicationId)
                    .WithTenantId(context.Account.Properties[AzureAccountPropertyType.Tenant])
                    .Build();

                TokenCacheHelper.EnableSerialization(app.UserTokenCache);

                authResult = app.AcquireTokenInteractive(new[] { $"{environment.PartnerCenterEndpoint}/user_impersonation" })
                    .WithPrompt(Prompt.ForceLogin)
                    .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                context.Account.Id = authResult.Account.Username;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.Account.HomeAccountId.ObjectId;
                context.AuthenticationType = AuthenticationTypes.AppPlusUser;
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

                IPublicClientApplication app = PublicClientApplicationBuilder.Create(context.ApplicationId)
                    .WithTenantId(context.Account.Properties[AzureAccountPropertyType.Tenant])
                    .Build();

                TokenCacheHelper.EnableSerialization(app.UserTokenCache);

                IEnumerable<IAccount> accounts = app.GetAccountsAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                authResult = app.AcquireTokenSilent(new[] { $"{environment.PartnerCenterEndpoint}/user_impersonation" }, accounts.FirstOrDefault())
                    .ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();

                context.Account.Id = authResult.Account.Username;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.Account.HomeAccountId.ObjectId;
                context.AuthenticationType = AuthenticationTypes.AppPlusUser;
            }

            return new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }
    }
}