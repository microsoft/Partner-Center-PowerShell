// -----------------------------------------------------------------------
// <copyright file="AuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using IdentityModel.Clients.ActiveDirectory;
    using PartnerCenter.Models.Partners;
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
        /// <param name="context">Contexted to be used when requesting a security token.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationResult Authenticate(PartnerContext context)
        {
            AuthenticationContext authContext;
            AuthenticationResult authResult;
            IAggregatePartner partnerOperations;
            PartnerEnvironment environment;
            OrganizationProfile profile;

            environment = PartnerEnvironment.PublicEnvironments[context.Environment];

            authContext = new AuthenticationContext(
                $"{environment.ActiveDirectoryAuthority}{context.TenantId}",
                TokenCache.DefaultShared);

            if (context.AccountType == AccountType.ServicePrincipal)
            {
                authResult = authContext.AcquireToken(
                    environment.AzureAdGraphEndpoint,
                    new ClientCredential(
                        context.Credentials.UserName,
                        context.Credentials.Password));

                context.Username = context.Credentials.UserName;
            }
            else if (PartnerSession.Instance.Context == null && context.Credentials == null)
            {
                authResult = authContext.AcquireToken(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    redirectUri,
                    PromptBehavior.Always,
                    UserIdentifier.AnyUser);

                context.AccountId = authResult.UserInfo.UniqueId;
                context.Username = authResult.UserInfo.DisplayableId;
                context.TenantId = authResult.TenantId;
            }
            else if (PartnerSession.Instance.Context == null && context.Credentials.Password != null)
            {
                authResult = authContext.AcquireToken(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    new UserCredential(
                        context.Credentials.UserName,
                        context.Credentials.Password));

                context.AccountId = authResult.UserInfo.UniqueId;
                context.Username = authResult.UserInfo.DisplayableId;
                context.TenantId = authResult.TenantId;
            }
            else
            {
                authResult = authContext.AcquireToken(
                    environment.PartnerCenterEndpoint,
                    context.ApplicationId,
                    redirectUri,
                    PromptBehavior.Never,
                    new UserIdentifier(context.Username, UserIdentifierType.RequiredDisplayableId));
            }

            if (PartnerSession.Instance.Context == null)
            {
                PartnerSession.Instance.Context = context;

                if (context.AccountType == AccountType.User)
                {
                    partnerOperations = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(context);
                    profile = partnerOperations.Profiles.OrganizationProfile.Get();

                    context.CountryCode = profile.DefaultAddress.Country;
                    context.Locale = profile.Culture;
                }
            }

            return authResult;

        }
    }
}