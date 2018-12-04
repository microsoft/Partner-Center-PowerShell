// -----------------------------------------------------------------------
// <copyright file="IPartnerFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Net.Http;
    using RequestContext;

    /// <summary>
    /// Creates instances of partner operations object.
    /// </summary>
    internal interface IPartnerFactory
    {
        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials);

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="requestContext">An operation context object.</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext);

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials, params DelegatingHandler[] handlers);

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext, params DelegatingHandler[] handlers);

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <param name="httpClient">The HTTP client to be used.</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials, HttpClient httpClient);

        /// <summary>
        /// Builds a <see cref="IPartner" /> instance and configures it using the provided partner credentials.
        /// </summary>
        /// <param name="credentials">The partner credentials.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="httpClient">The HTTP client to be used.</param>
        /// <returns>A configured partner object.</returns>
        IPartner Build(IPartnerCredentials credentials, IRequestContext requestContext, HttpClient httpClient);
    }
}