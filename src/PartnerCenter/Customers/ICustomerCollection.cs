// -----------------------------------------------------------------------
// <copyright file="ICustomerCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Customers;
    using Models.Query;
    using RelationshipRequests;
    using Usage;

    /// <summary>
    /// Represents the behavior of the partner customers.
    /// </summary>
    public interface ICustomerCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<Customer, SeekBasedResourceCollection<Customer>>, IEntityCreateOperations<Customer, Customer>, IEntitySelector<ICustomer>
    {
        /// <summary>
        /// Gets the relationship request behavior used to relate customers into the partner.
        /// </summary>
        ICustomerRelationshipRequest RelationshipRequest { get; }

        /// <summary>
        /// Gets the customer usage records behavior for the partner.
        /// </summary>
        ICustomerUsageRecordCollection UsageRecords { get; }

        /// <summary>
        /// Queries customers associated to the partner.
        /// - Count queries are not supported by this operation.
        /// - You can set the page size or filter or do both at the same time.
        /// - Sort is not supported.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="customersQuery">A query to apply onto customers. Check <see cref="QueryFactory" /> to see how to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customers.</returns>
        SeekBasedResourceCollection<Customer> Query(IQuery customersQuery, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Queries customers associated to the partner.
        /// - Count queries are not supported by this operation.
        /// - You can set the page size or filter or do both at the same time.
        /// - Sort is not supported.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="customersQuery">A query to apply onto customers. Check <see cref="QueryFactory" /> to see how to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customers.</returns>
        Task<SeekBasedResourceCollection<Customer>> QueryAsync(IQuery customersQuery, CancellationToken cancellationToken = default(CancellationToken));
    }
}