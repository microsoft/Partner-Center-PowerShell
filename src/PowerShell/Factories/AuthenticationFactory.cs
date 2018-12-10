// -----------------------------------------------------------------------
// <copyright file="AuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Globalization;
    using System.Security;
    using System.Threading.Tasks;
    using IdentityModel.Clients.ActiveDirectory;
    using Profile;

    /// <summary>
    /// Factory used to perform authentication operations.
    /// </summary>
    public class AuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// The redirect URI used when performing app + user authentication.
        /// </summary>
        private static readonly Uri redirectUri = new Uri("urn:ietf:wg:oauth:2.0:oob");

        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="password">Password used when requesting a security token.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationToken Authenticate(PartnerContext context, SecureString password = null)
        {
            AuthenticationContext authContext;
            AuthenticationResult authResult;
            PartnerEnvironment environment;

            environment = PartnerEnvironment.PublicEnvironments[context.Environment];

            authContext = new AuthenticationContext(
                $"{environment.ActiveDirectoryAuthority}{context.Account.Properties[AzureAccountPropertyType.Tenant]}");

            if (context.Account.Type == AccountType.AccessToken)
            {
                return new AuthenticationToken(
                    context.Account.Properties[AzureAccountPropertyType.AccessToken],
                    DateTime.Parse(context.Account.Properties[AzureAccountPropertyType.AccessTokenExpiration], CultureInfo.CurrentCulture));
            }
            else if (context.Account.Type == AccountType.ServicePrincipal)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.AzureAdGraphEndpoint,
                    new ClientCredential(
                        context.Account.Id,
                        context.Account.Properties[AzureAccountPropertyType.ServicePrincipalSecret]))).Result;
            }
            else if (PartnerSession.Instance.Context == null && password == null)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    redirectUri,
                    new PlatformParameters(PromptBehavior.Always),
                    UserIdentifier.AnyUser)).Result;

                context.Account.Id = authResult.UserInfo.DisplayableId;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.UserInfo.UniqueId;
            }
            else if (PartnerSession.Instance.Context == null && password != null)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    new UserPasswordCredential(
                        context.Account.Id,
                        password))).Result;

                context.Account.Id = authResult.UserInfo.DisplayableId;
                context.Account.Properties[AzureAccountPropertyType.Tenant] = authResult.TenantId;
                context.Account.Properties[AzureAccountPropertyType.UserIdentifier] = authResult.UserInfo.UniqueId;
            }
            else
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    redirectUri,
                    new PlatformParameters(PromptBehavior.Never),
                    new UserIdentifier(context.Account.Id, UserIdentifierType.RequiredDisplayableId))).Result;
            }

            return new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }
    }
}