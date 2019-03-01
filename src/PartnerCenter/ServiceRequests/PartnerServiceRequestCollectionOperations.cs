// -----------------------------------------------------------------------
// <copyright file="PartnerServiceRequestCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.ServiceRequests;
    using Newtonsoft.Json;

    /// <summary>
    /// The partner's service requests operations and implementation.
    /// </summary>
    internal class PartnerServiceRequestCollectionOperations : BasePartnerComponent<string>, IPartnerServiceRequestCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerServiceRequestCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public PartnerServiceRequestCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }


        /// <summary>
        /// Gets the specified service.
        /// </summary>
        /// <param name="id">The identifier of the service request.</param>
        /// <returns>The available service request operations.</returns>
        public IServiceRequest this[string id] => ById(id);

        /// <summary>
        /// Gets a collection of operations that can be performed on support topics.
        /// </summary>
        /// <returns>a collection of operations that can be performed on support topics.</returns>
        public ISupportTopicsCollection SupportTopics => new SupportTopicsCollectionOperations(Partner);

        /// <summary>
        /// Gets the specified service.
        /// </summary>
        /// <param name="id">The identifier of the service request.</param>
        /// <returns>The available service request operations.</returns>
        public IServiceRequest ById(string id)
        {
            return new PartnerServiceRequestOperations(Partner, id);
        }

        /// <summary>
        /// Creates a service request.
        /// </summary>
        /// <param name="serviceRequest">The service request to be created.</param>
        /// <param name="agentLocale">The agent locale.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The created service request with associated identifier.</returns>
        public async Task<ServiceRequest> CreateAsync(ServiceRequest serviceRequest, string agentLocale, CancellationToken cancellationToken = default)
        {
            serviceRequest.AssertNotNull(nameof(serviceRequest));
            agentLocale.AssertNotEmpty(nameof(agentLocale));

            return await Partner.ServiceClient.PostAsync<ServiceRequest, ServiceRequest>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CreateServiceRequest.Path}",
                        agentLocale),
                    UriKind.Relative),
                serviceRequest,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the service requests associated with the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A collection of service requests.</returns>
        public async Task<ResourceCollection<ServiceRequest>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceRequest>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAllServiceRequestsPartner.Path}",
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
                    PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Parameters.Offset,
                    query.Index.ToString(CultureInfo.InvariantCulture));

                parameters.Add(
                     PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Parameters.Size,
                     query.PageSize.ToString(CultureInfo.InvariantCulture));
            }

            if (query.Filter != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Parameters.Filter,
                    JsonConvert.SerializeObject(query.Filter));
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceRequest>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<ServiceRequest>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
