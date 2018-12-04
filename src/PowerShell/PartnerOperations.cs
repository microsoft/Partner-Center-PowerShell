// -----------------------------------------------------------------------
// <copyright file="PartnerOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell
{
    using System;
    using System.Net.Http;
    using Customers;
    using Network;
    using RequestContext;

    /// <summary>
    /// Implementation of the partner operations.
    /// </summary>
    internal class PartnerOperations : IPartner
    {
        /// <summary>
        /// Provides access to the available customer operations.
        /// </summary>
        private readonly Lazy<ICustomerCollection> customers;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        private PartnerOperations()
        {
            customers = new Lazy<ICustomerCollection>(() => new CustomerCollectionOperations(this));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        public PartnerOperations(IPartnerCredentials credentials, IRequestContext context) : this()
        {
            Credentials = credentials;
            RequestContext = context;

            ServiceClient = new PartnerServiceClient(PartnerService.Instance.ApiRootUrl);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerOperations" /> class.
        /// </summary>
        /// <param name="credentials">Credentials to be used when accessing resources.</param>
        /// <param name="requestContext">The context used to perform operations.</param>
        /// <param name="handlers">List of handlers from top to bottom (outer handler is the first in the list).</param>
        public PartnerOperations(IPartnerCredentials credentials, IRequestContext requestContext, params DelegatingHandler[] handlers)
            : this()
        {
            Credentials = credentials;
            RequestContext = requestContext;

            ServiceClient = new PartnerServiceClient(
                PartnerService.Instance.ApiRootUrl,
                handlers);
        }

        public PartnerOperations(IPartnerCredentials credentials, IRequestContext requestContext, HttpClient httpClient)
            : this()
        {
            Credentials = credentials;
            RequestContext = requestContext;

            ServiceClient = new PartnerServiceClient(
                PartnerService.Instance.ApiRootUrl,
                httpClient);
        }

        /// <summary>
        /// Gets the partner credentials.
        /// </summary>
        public IPartnerCredentials Credentials { get; private set; }

        /// <summary>
        /// Gets the the available customer operations. 
        /// </summary>
        public ICustomerCollection Customers => customers.Value;

        /// <summary>
        /// Gets the partner context.
        /// </summary>
        public IRequestContext RequestContext { get; private set; }

        /// <summary>
        /// Gets the partner service client.
        /// </summary>
        public IPartnerServiceClient ServiceClient { get; private set; }
    }
}