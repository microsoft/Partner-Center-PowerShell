// -----------------------------------------------------------------------
// <copyright file="PartnerCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System;
    using System.Threading.Tasks;
    using RequestContext;

    /// <summary>
    /// Use this class to generate Partner Center API credentials. User plus application based authentication and application only authentication
    /// are supported.
    /// </summary>
    public class PartnerCredentials
    {
        /// <summary>
        /// A singleton instance of the partner credentials.
        /// </summary>
        private static Lazy<PartnerCredentials> instance = new Lazy<PartnerCredentials>(() => new PartnerCredentials());

        /// <summary>
        /// Prevents a default instance of the <see cref="PartnerCredentials" /> class from being created.
        /// </summary>
        private PartnerCredentials()
        {
        }

        /// <summary>
        /// Gets an instance of the partner credentials.
        /// </summary>
        public static PartnerCredentials Instance => instance.Value;

        /// <summary>
        /// Generates partner credentials using Azure Active Directory application credentials with the provided AAD overrides.
        /// </summary>
        /// <param name="clientId">The client id of the application in Azure Active Directory. This application should be an Azure web application.</param>
        /// <param name="applicationSecret">The application secret with Azure Active Directory.</param>
        /// <param name="aadApplicationDomain">The application domain in Azure Active Directory.</param>
        /// <param name="aadAuthorityEndpoint">The Active Directory authority endpoint.</param>
        /// <param name="graphEndpoint">The Azure AD Graph endpoint.</param>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>The partner service credentials.</returns>
        public IPartnerCredentials GenerateByApplicationCredentials(string clientId, string applicationSecret, string aadApplicationDomain, string aadAuthorityEndpoint = null, string graphEndpoint = null, IRequestContext requestContext = null)
        {
            return PartnerService.SynchronousExecute(() => GenerateByApplicationCredentialsAsync(
                clientId,
                applicationSecret,
                aadApplicationDomain,
                aadAuthorityEndpoint,
                graphEndpoint,
                requestContext));
        }

        /// <summary>
        /// Generates partner credentials using Azure Active Directory application credentials with the provided AAD overrides.
        /// </summary>
        /// <param name="clientId">The client id of the application in Azure Active Directory. This application should be an Azure web application.</param>
        /// <param name="applicationSecret">The application secret with Azure Active Directory.</param>
        /// <param name="aadApplicationDomain">The application domain in Azure Active Directory.</param>
        /// <param name="aadAuthorityEndpoint">The Active Directory authority endpoint.</param>
        /// <param name="graphEndpoint">The Azure AD Graph endpoint.</param>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>The partner service credentials.</returns>
        public async Task<IPartnerCredentials> GenerateByApplicationCredentialsAsync(string clientId, string applicationSecret, string aadApplicationDomain, string aadAuthorityEndpoint = null, string graphEndpoint = null, IRequestContext requestContext = null)
        {
            clientId.AssertNotEmpty(nameof(clientId));
            applicationSecret.AssertNotEmpty(nameof(applicationSecret));
            aadApplicationDomain.AssertNotEmpty(nameof(aadApplicationDomain));
            aadAuthorityEndpoint.AssertNotEmpty(nameof(aadAuthorityEndpoint));
            graphEndpoint.AssertNotEmpty(nameof(graphEndpoint));

            ApplicationPartnerCredentials partnerCredentials = new ApplicationPartnerCredentials(
                clientId,
                applicationSecret,
                aadApplicationDomain,
                aadAuthorityEndpoint,
                graphEndpoint);

            await partnerCredentials.AuthenticateAsync(requestContext).ConfigureAwait(false);

            return partnerCredentials;
        }

        /// <summary>
        /// Generates partner credentials using a user plus application Azure Active Directory token.
        /// </summary>
        /// <param name="clientId">The client id of the application in Azure Active Directory. This application should be an Azure native application.</param>
        /// <param name="authenticationToken">The Azure Active Directory token.</param>
        /// <param name="aadTokenRefresher">An optional delegate which will be called when the Azure Active Directory token
        /// expires and can no longer be used to generate the partner credentials. This delegate should return
        /// an up to date Azure Active Directory token.</param>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>The partner service credentials.</returns>
        public IPartnerCredentials GenerateByUserCredentials(string clientId, AuthenticationToken authenticationToken, TokenRefresher aadTokenRefresher = null, IRequestContext requestContext = null)
        {
            return PartnerService.SynchronousExecute(() => GenerateByUserCredentialsAsync(
                clientId, 
                authenticationToken, 
                aadTokenRefresher, 
                requestContext));
        }

        /// <summary>
        /// Generates partner credentials using a user plus application Azure Active Directory token.
        /// </summary>
        /// <param name="clientId">The client id of the application in Azure Active Directory. This application should be an Azure native application.</param>
        /// <param name="authenticationToken">The Azure Active Directory token.</param>
        /// <param name="aadTokenRefresher">An optional delegate which will be called when the Azure Active Directory token
        /// expires and can no longer be used to generate the partner credentials. This delegate should return
        /// an up to date Azure Active Directory token.</param>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>The partner service credentials.</returns>
        public async Task<IPartnerCredentials> GenerateByUserCredentialsAsync(string clientId, AuthenticationToken authenticationToken, TokenRefresher aadTokenRefresher = null, IRequestContext requestContext = null)
        {
            UserPartnerCredentials partnerCredentials = new UserPartnerCredentials(clientId, authenticationToken, aadTokenRefresher);

            await partnerCredentials.AuthenticateAsync(requestContext).ConfigureAwait(false);

            return partnerCredentials;
        }
    }
}