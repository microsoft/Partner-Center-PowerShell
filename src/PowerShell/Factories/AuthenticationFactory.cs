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
        /// Acquires a security token from the authority.
        /// </summary>
        /// <param name="applicationId">Identifier of the client requesting the token.</param>
        /// <param name="account">Account information used when requesting the token.</param>
        /// <param name="password">Password, or secret, used when requesting the token.</param>
        /// <param name="environmentName">Name of the environment to be used when requesting the token.</param>
        /// <param name="tokenCache">Token cache used to lookup cached tokens.</param>
        /// <returns>The access token and related information.</returns>
        public AuthenticationResult Authenticate(
            string applicationId,
            AzureAccount account,
            SecureString password,
            EnvironmentName environmentName,
            TokenCache tokenCache)
        {
            AuthenticationContext authContext;
            AuthenticationResult authResult;
            PartnerEnvironment environment;

            environment = PartnerEnvironment.PublicEnvironments[environmentName];

            authContext = new AuthenticationContext(
                $"{environment.ActiveDirectoryAuthority}{account.Properties[AzureAccountPropertyType.Tenant]}",
                tokenCache);

            if (account.Type == AccountType.ServicePrincipal)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.AzureAdGraphEndpoint,
                    new ClientCredential(
                        account.Id,
                        account.Properties[AzureAccountPropertyType.ServicePrincipalSecret]))).Result;
            }
            else if (string.IsNullOrEmpty(account.Id) && password == null)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    applicationId,
                    redirectUri,
                    new PlatformParameters(PromptBehavior.Never),
                    new UserIdentifier(account.Id, UserIdentifierType.RequiredDisplayableId))).Result;
            }
            else if (!string.IsNullOrEmpty(account.Id) && password != null)
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    applicationId,
                    new UserPasswordCredential(
                        account.Id,
                        password))).Result;
            }
            else
            {
                authResult = Task.Run(() => authContext.AcquireTokenAsync(
                    environment.PartnerCenterEndpoint,
                    applicationId,
                    redirectUri,
                    new PlatformParameters(PromptBehavior.Always),
                    UserIdentifier.AnyUser)).Result;
            }

            return authResult;
        }

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
                $"{environment.ActiveDirectoryAuthority}{context.Account.Properties[AzureAccountPropertyType.Tenant]}",
                context.TokenCache);

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