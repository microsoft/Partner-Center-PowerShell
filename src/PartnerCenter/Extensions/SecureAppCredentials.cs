// -----------------------------------------------------------------------
// <copyright file="SecureAppCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using System.Threading.Tasks;
    using RequestContext;

    /// <summary>
    /// Partner service credentials based on the secure application model.
    /// </summary>
    internal class SecureAppCredentials : BasePartnerCredentials
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
        /// Initializes static members of the <see cref="SecureAppCredentials" /> class.
        /// </summary>
        static SecureAppCredentials()
        {
            PartnerService.Instance.RefreshCredentials += new PartnerService.RefreshCredentialsHandler(OnCredentialsRefreshNeededAsync);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecureAppCredentials" /> class.
        /// </summary>
        /// <param name="aadApplicationId">The application Id in Azure Active Directory.</param>
        /// <param name="aadApplicationSecret">The application secret in Azure Active Directory.</param>
        /// <param name="aadApplicationDomain">The application domain in Azure Active Directory.</param>
        /// <param name="refreshToken">The refresh token </param>
        /// <param name="aadAuthorityEndpoint">The Active Directory authority endpoint.</param>
        /// <param name="graphApiEndpoint">The AAD graph API endpoint.</param>
        public SecureAppCredentials(string aadApplicationId, string aadApplicationSecret, string aadApplicationDomain, string refreshToken, string aadAuthorityEndpoint, string graphApiEndpoint)
          : base(aadApplicationId)
        {
            aadApplicationId.AssertNotEmpty(nameof(aadApplicationId));
            aadApplicationSecret.AssertNotEmpty(nameof(aadApplicationSecret));
            aadApplicationDomain.AssertNotEmpty(nameof(aadApplicationDomain));

            if (string.IsNullOrEmpty(aadAuthorityEndpoint))
            {
                aadAuthorityEndpoint = DefaultAadAuthority;
            }

            if (string.IsNullOrEmpty(graphApiEndpoint))
            {
                graphApiEndpoint = DefaultGraphEndpoint;
            }

            applicationSecret = aadApplicationSecret;
            this.aadApplicationDomain = aadApplicationDomain;
            activeDirectoryAuthority = aadAuthorityEndpoint;
            this.graphApiEndpoint = graphApiEndpoint;
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