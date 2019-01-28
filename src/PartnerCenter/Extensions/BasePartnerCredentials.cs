// -----------------------------------------------------------------------
// <copyright file="BasePartnerCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using System;
    using System.Threading.Tasks;
    using RequestContext;

    /// <summary>
    /// A base implementation for partner credentials.
    /// </summary>
    internal abstract class BasePartnerCredentials : IPartnerCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePartnerCredentials" /> class.
        /// </summary>
        /// <param name="applicationId">The Azure Active Directory application identifier.</param>
        protected BasePartnerCredentials(string applicationId)
        {
            ApplicationId = applicationId;
        }

        /// <summary>
        /// Gets the Azure Active Directory application identifier.
        /// </summary>
        protected string ApplicationId { get; private set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        protected AuthenticationToken AADToken { get; set; }

        /// <summary>
        /// Gets the partner service token.
        /// </summary>
        public string PartnerServiceToken => AADToken.Token;

        /// <summary>
        /// Gets the expiry time in UTC for the token.
        /// </summary>
        public DateTimeOffset ExpiresAt => AADToken.ExpiryTime;

        /// <summary>
        /// Indicates whether the partner credentials have expired or not.
        /// </summary>
        /// <returns>True if credentials have expired. False if not.</returns>
        public bool IsExpired()
        {
            return AADToken.IsExpired();
        }

        /// <summary>
        /// Authenticates with the partner service.
        /// </summary>
        /// <param name="requestContext">An optional request context.</param>
        /// <returns>A task that is complete when authentication is finished.</returns>
        public virtual async Task AuthenticateAsync(IRequestContext requestContext = null)
        {
            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}
