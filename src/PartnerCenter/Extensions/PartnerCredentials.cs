// -----------------------------------------------------------------------
// <copyright file="PartnerCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using System.Threading.Tasks;
    using RequestContext;

    /// <summary>
    /// Use this class to generate Partner Center API credentials. User plus application based authentication and application only authentication
    /// are supported.
    /// </summary>
    public static class PartnerCredentials
    {
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
        public static async Task<IPartnerCredentials> GenerateByApplicationCredentialsAsync(string clientId, string applicationSecret, string aadApplicationDomain, string aadAuthorityEndpoint = null, string graphEndpoint = null, IRequestContext requestContext = null)
        {
            clientId.AssertNotEmpty(nameof(clientId));
            applicationSecret.AssertNotEmpty(nameof(applicationSecret));
            aadApplicationDomain.AssertNotEmpty(nameof(aadApplicationDomain));
 
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
        /// Generates partner credentials using app + user authentication.
        /// </summary>
        /// <param name="clientId">The client id of the application in Azure Active Directory. This application should be an Azure native application.</param>
        /// <param name="authenticationToken">The Azure Active Directory token.</param>
        /// <param name="aadTokenRefresher">An optional delegate which will be called when the Azure Active Directory token
        /// expires and can no longer be used to generate the partner credentials. This delegate should return
        /// an up to date Azure Active Directory token.</param>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>The partner service credentials.</returns>
        public static async Task<IPartnerCredentials> GenerateByUserCredentialsAsync(string clientId, AuthenticationToken authenticationToken, TokenRefresher aadTokenRefresher = null, IRequestContext requestContext = null)
        {
            UserPartnerCredentials partnerCredentials = new UserPartnerCredentials(clientId, authenticationToken, aadTokenRefresher);

            await partnerCredentials.AuthenticateAsync(requestContext).ConfigureAwait(false);

            return partnerCredentials;
        }
    }
}