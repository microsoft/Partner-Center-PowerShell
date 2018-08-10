// -----------------------------------------------------------------------
// <copyright file="AuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Security;
    using Authentication;
    using Common;
    using IdentityModel.Clients.ActiveDirectory;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Factory that handles authenticaton operations.
    /// </summary>
    public class AuthenticationFactory : IAuthenticationFactory
    {
        public PartnerContext Authenticate(string applicationId, EnvironmentName environment, string username, SecureString password, string tenantId)
        {
            AuthenticationResult authResult;
            IPartner partner;
            OrganizationProfile profile;
            PartnerContext context;

            applicationId.AssertNotEmpty(nameof(applicationId));
            environment.AssertNotNull(nameof(environment));
            tenantId.AssertNotEmpty(nameof(tenantId));

            try
            {
                context = new PartnerContext
                {
                    ApplicationId = applicationId,
                    Environment = environment,
                    TenantId = tenantId,
                    Username = username
                };

                authResult = Authenticate(context, password);

                partner = PartnerSession.Instance.ClientFactory.CreatePartnerOperations(context);
                profile = partner.Profiles.OrganizationProfile.Get();

                context.CountryCode = profile.DefaultAddress.Country;
                context.Locale = profile.Culture;
                context.UserId = authResult.UserInfo.UniqueId;

                return context;
            }
            finally
            {
                authResult = null;
                partner = null;
                profile = null;
            }
        }

        /// <summary>
        /// Authenticates the user using the specified parameters.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <param name="password">The password used to authenicate the user. This value can be null.</param>
        /// <returns>The result from the authentication request.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="context"/> is null.
        /// </exception>
        public AuthenticationResult Authenticate(PartnerContext context, SecureString password)
        {
            AuthenticationContext authContext;
            AuthenticationResult authResult;
            PartnerEnvironment environment;

            context.AssertNotNull(nameof(context));

            try
            {
                environment = PartnerEnvironment.PublicEnvironments[context.Environment];

                authContext = new AuthenticationContext($"{environment.ActiveDirectoryAuthority}{context.TenantId}");

                if (string.IsNullOrEmpty(context.Username))
                {
                    authResult = authContext.AcquireToken(
                        environment.PartnerCenterEndpoint,
                        context.ApplicationId,
                        new Uri("urn:ietf:wg:oauth:2.0:oob"),
                        PromptBehavior.Always,
                        UserIdentifier.AnyUser);

                    context.TenantId = authResult.TenantId;
                    context.Username = authResult.UserInfo.DisplayableId;
                }
                else if (password != null)
                {
                    authResult = authContext.AcquireToken(
                        environment.PartnerCenterEndpoint,
                        context.ApplicationId,
                        new UserCredential(
                            context.Username,
                            password));

                    context.TenantId = authResult.TenantId;
                    context.Username = authResult.UserInfo.DisplayableId;
                }
                else
                {
                    authResult = authContext.AcquireToken(
                        environment.PartnerCenterEndpoint,
                        context.ApplicationId,
                        new Uri("urn:ietf:wg:oauth:2.0:oob"),
                        PromptBehavior.Never,
                        new UserIdentifier(context.Username, UserIdentifierType.RequiredDisplayableId));
                }

                return authResult;
            }
            finally
            {
                authContext = null;
                environment = null;
            }
        }
    }
}