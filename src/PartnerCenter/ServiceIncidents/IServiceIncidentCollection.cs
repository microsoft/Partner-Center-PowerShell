// -----------------------------------------------------------------------
// <copyright file="IServiceIncidentCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceIncidents
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Query;
    using Models.ServiceIncidents;

    /// <summary>
    /// Defines the operations available on service incidents.
    /// </summary>
    public interface IServiceIncidentCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<ServiceIncidents, ResourceCollection<ServiceIncidents>>
    {
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
        ResourceCollection<ServiceIncidents> Query(IQuery query, CancellationToken cancellationToken = default(CancellationToken));

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
        Task<ResourceCollection<ServiceIncidents>> QueryAsync(IQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}