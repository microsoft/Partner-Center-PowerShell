// -----------------------------------------------------------------------
// <copyright file="ApplicationPartnerCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Extensions
{
    using System;
    using System.Threading.Tasks;
    using IdentityModel.Clients.ActiveDirectory;
    using RequestContext;

    /// <summary>
    /// Partner service credentials based on azure active directory application credentials.
    /// </summary>
    internal class ApplicationPartnerCredentials : BasePartnerCredentials
    {
        /// <summary>
        /// The default AAD authority endpoint.
        /// </summary>
        private const string DefaultAadAuthority = "https://login.microsoftonline.com";

        /// <summary>
        /// The default Azure AD Graph endpoint.
        /// </summary>
        private const string DefaultGraphEndpoint = "https://graph.windows.net";

        /// <summary>
        /// The Azure Active Directory application secret.
        /// </summary>
        private readonly string applicationSecret;

        /// <summary>
        /// The application domain in Azure Active Directory.
        /// </summary>
        private readonly string aadApplicationDomain;

        /// <summary>
        /// The Active Directory authentication endpoint.
        /// </summary>
        private readonly string activeDirectoryAuthority;

        /// <summary>
        /// The Azure AD Graph API endpoint.
        /// </summary>
        private readonly string graphApiEndpoint;

        /// <summary>
        /// Initializes static members of the <see cref="ApplicationPartnerCredentials" /> class.
        /// </summary>
        static ApplicationPartnerCredentials()
        {
            PartnerService.Instance.RefreshCredentials += new PartnerService.RefreshCredentialsHandler(ApplicationPartnerCredentials.OnCredentialsRefreshNeededAsync);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.Store.PartnerCenter.Extensions.ApplicationPartnerCredentials" /> class.
        /// </summary>
        /// <param name="aadApplicationId">The application Id in Azure Active Directory.</param>
        /// <param name="aadApplicationSecret">The application secret in Azure Active Directory.</param>
        /// <param name="aadApplicationDomain">The application domain in Azure Active Directory.</param>
        public ApplicationPartnerCredentials(string aadApplicationId, string aadApplicationSecret, string aadApplicationDomain)
          : this(aadApplicationId, aadApplicationSecret, aadApplicationDomain, DefaultAadAuthority, DefaultGraphEndpoint)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Microsoft.Store.PartnerCenter.Extensions.ApplicationPartnerCredentials" /> class.
        /// </summary>
        /// <param name="aadApplicationId">The application Id in Azure Active Directory.</param>
        /// <param name="aadApplicationSecret">The application secret in Azure Active Directory.</param>
        /// <param name="aadApplicationDomain">The application domain in Azure Active Directory.</param>
        /// <param name="aadAuthorityEndpoint">The active directory authority endpoint.</param>
        /// <param name="graphApiEndpoint">The AAD graph API endpoint.</param>
        public ApplicationPartnerCredentials(string aadApplicationId, string aadApplicationSecret, string aadApplicationDomain, string aadAuthorityEndpoint, string graphApiEndpoint)
          : base(aadApplicationId)
        {
            if (string.IsNullOrWhiteSpace(aadApplicationSecret))
            {
                throw new ArgumentException("aadApplicationSecret has to be set");
            }

            if (string.IsNullOrWhiteSpace(aadApplicationDomain))
            {
                throw new ArgumentException("aadApplicationDomain has to be set");
            }
            if (string.IsNullOrWhiteSpace(aadAuthorityEndpoint))
            {
                throw new ArgumentException("aadAuthorityEndpoint has to be set");
            }
            if (string.IsNullOrWhiteSpace(graphApiEndpoint))
            {
                throw new ArgumentException("graphApiEndpoint has to be set");
            }

            applicationSecret = aadApplicationSecret;
            this.aadApplicationDomain = aadApplicationDomain;
            activeDirectoryAuthority = aadAuthorityEndpoint;
            this.graphApiEndpoint = graphApiEndpoint;
        }

        /// <summary>Authenticates with the partner service.</summary>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>A task that is complete when the authentication is complete.</returns>
        public override async Task AuthenticateAsync(IRequestContext requestContext = null)
        {
            AuthenticationContext authContext = new AuthenticationContext(activeDirectoryAuthority);

            if (requestContext != null)
            {
                authContext.CorrelationId = requestContext.CorrelationId;
            }

            AuthenticationResult authResult = await authContext.AcquireTokenAsync(
                graphApiEndpoint,
                new ClientCredential(
                    ApplicationId,
                    applicationSecret)).ConfigureAwait(false);

            AADToken = new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn);
        }

        /// <summary>
        /// Called when a partner credentials instance needs to be refreshed.
        /// </summary>
        /// <param name="credentials">The outdated partner credentials.</param>
        /// <param name="context">The partner context.</param>
        /// <returns>A task that is complete when the credential refresh is complete.</returns>
        private static async Task OnCredentialsRefreshNeededAsync(IPartnerCredentials credentials, IRequestContext context)
        {
            if (credentials is ApplicationPartnerCredentials partnerCredentials)
            {
                await partnerCredentials.AuthenticateAsync(context).ConfigureAwait(false);
            }
        }
    }
}