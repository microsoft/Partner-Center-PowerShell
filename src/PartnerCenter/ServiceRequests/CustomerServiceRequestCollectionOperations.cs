// -----------------------------------------------------------------------
// <copyright file="CustomerServiceRequestCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.ServiceRequests;
    using Newtonsoft.Json;

    /// <summary>
    /// The customer's service requests operations implementation.
    /// </summary>
    internal class CustomerServiceRequestCollectionOperations : BasePartnerComponent<string>, IServiceRequestCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerServiceRequestCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerServiceRequestCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets the specified service request operations.
        /// </summary>
        /// <param name="id">The service request identifier.</param>
        /// <returns>The available service request operations.</returns>
        public IServiceRequest this[string id] => ById(id);

        /// <summary>
        /// Gets the specified service request operations.
        /// </summary>
        /// <param name="id">The service request identifier.</param>
        /// <returns>The available service request operations.</returns>
        public IServiceRequest ById(string id)
        {
            return new CustomerServiceRequestOperations(Partner, Context, id);
        }

        /// <summary>
        /// Gets the service requests associated to the customer.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of service requests.</returns>
        public async Task<ResourceCollection<ServiceRequest>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceRequest>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAllServiceRequestsCustomer.Path}",
                        Context),
                    UriKind.Relative),
                new ResourceCollectionConverter<ServiceRequest>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries service requests.
        /// - Count queries are not supported by this operation.
        /// - You can set the page size or filter or do both at the same time.
        /// - Sort is not supported. Default sorting is on status field.
        /// </summary>
        /// <param name="query">A query to apply onto service requests. Check <see cref="QueryFactory" /> to see how
        /// to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested service requests.</returns>
        public async Task<ResourceCollection<ServiceRequest>> QueryAsync(IQuery query, CancellationToken cancellationToken = default)
        {
            query.AssertNotNull(nameof(query));

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (query.Type == QueryType.Indexed)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.SearchCustomerServiceRequests.Parameters.Offset,
                    query.Index.ToString(CultureInfo.InvariantCulture));

                parameters.Add(
                     PartnerService.Instance.Configuration.Apis.SearchCustomerServiceRequests.Parameters.Size,
                     query.PageSize.ToString(CultureInfo.InvariantCulture));
            }

            if (query.Filter != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.SearchCustomerServiceRequests.Parameters.Filter,
                     WebUtility.UrlEncode(JsonConvert.SerializeObject(query.Filter)));
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceRequest>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.SearchCustomerServiceRequests.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<ServiceRequest>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}