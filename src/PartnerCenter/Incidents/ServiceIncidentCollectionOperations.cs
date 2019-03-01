// -----------------------------------------------------------------------
// <copyright file="ServiceIncidentCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Incidents
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Incidents;
    using Models.JsonConverters;
    using Models.Query;

    /// <summary>
    /// Service incident collection operations implementation class.
    /// </summary>
    internal class ServiceIncidentCollectionOperations : BasePartnerComponent<string>, IServiceIncidentCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceIncidentCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public ServiceIncidentCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets all service incidents.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service incidents.</returns>
        public async Task<ResourceCollection<ServiceIncidents>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceIncidents>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetServiceIncidents.Path}",
                    UriKind.Relative),
                new ResourceCollectionConverter<ServiceIncidents>(),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Queries service incidents.
        /// </summary>
        /// <param name="query">A query to retrieve service incidents based on the active status.
        /// The <see cref="QueryFactory" /> can be used to build queries.
        /// Service incident queries support simple queries. You can filter service incidents using their active status.
        /// <see cref="ServiceIncidentSearchField" /> lists
        /// the supported search fields. You can use the <see cref="FieldFilterOperation" /> enumeration to specify filtering operations.
        /// Supported filtering operations are: equals.
        /// </param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The list of service incidents that match the query.</returns>
        public async Task<ResourceCollection<ServiceIncidents>> QueryAsync(IQuery query, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (query?.Filter != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Parameters.Filter,
                    query.Filter.ToString());
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<ServiceIncidents>>(
                new Uri
                    ($"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.SearchPartnerServiceRequests.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<ServiceIncidents>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
