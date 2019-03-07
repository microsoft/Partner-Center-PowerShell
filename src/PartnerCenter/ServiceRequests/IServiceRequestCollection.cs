// -----------------------------------------------------------------------
// <copyright file="IServiceRequestCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Query;
    using Models.ServiceRequests;

    /// <summary>
    /// Represents the behavior of service requests.
    /// </summary>
    public interface IServiceRequestCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<ServiceRequest, ResourceCollection<ServiceRequest>>, IEntitySelector<IServiceRequest>
    {
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
        Task<ResourceCollection<ServiceRequest>> QueryAsync(IQuery query, CancellationToken cancellationToken = default);
    }
}