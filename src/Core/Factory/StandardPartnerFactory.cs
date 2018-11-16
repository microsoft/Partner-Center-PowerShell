// -----------------------------------------------------------------------
// <copyright file="PartnerService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Factory
{
    using System.Net.Http;
    using RequestContext;

    /// <summary>
    /// Standard implementation of the partner factory.
    /// </summary>
    internal class StandardPartnerFactory : IPartnerFactory
    {
        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials)
        {
            return new PartnerOperations(credentials, RequestContextFactory.Create());
        }

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext)
        {
            return new PartnerOperations(credentials, requestContext);
        }

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials, params DelegatingHandler[] handlers)
        {
            return new PartnerOperations(credentials, RequestContextFactory.Create(), handlers);
        }

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext, params DelegatingHandler[] handlers)
        {
            return new PartnerOperations(credentials, requestContext, handlers);
        }

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <param name="httpClient">The HTTP client to be used.</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials, HttpClient httpClient)
        {
            return new PartnerOperations(credentials, RequestContextFactory.Create(), httpClient);
        }

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials. Use the extensions to obtain these.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="httpClient">The HTTP client to be used.</param>
        /// <returns>A configured partner object.</returns>
        public IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext, HttpClient httpClient)
        {
            return new PartnerOperations(credentials, requestContext, httpClient);
        }
    }
}