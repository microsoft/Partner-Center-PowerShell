// -----------------------------------------------------------------------
// <copyright file="ICustomerUserCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Query;
    using Models.Users;

    /// <summary>
    /// Represents the behavior of the customers users.
    /// </summary>
    public interface ICustomerUserCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<CustomerUser, SeekBasedResourceCollection<CustomerUser>>, IEntityCreateOperations<CustomerUser, CustomerUser>, IEntitySelector<ICustomerUser>
    {
        /// <summary>
        /// Queries users associated to the customer.
        /// - Count queries are not supported by this operation.
        /// - You can set page size, filter and sort option.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="query">A query to apply onto customer users. Check <see cref="QueryFactory" /> to see how
        /// to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customer users.</returns>
        SeekBasedResourceCollection<CustomerUser> Query(IQuery query, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Queries users of customer.
        /// - Count queries are not supported by this operation.
        /// - You can set page size, filter and sort option.
        /// - You can navigate to other pages by specifying a seek query with the seek operation and the continuation
        ///   token sent by the previous operation.
        /// </summary>
        /// <param name="query">A query to apply onto customer users. Check <see cref="QueryFactory" /> to see how
        /// to build queries.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested customer users.</returns>
        Task<SeekBasedResourceCollection<CustomerUser>> QueryAsync(IQuery query, CancellationToken cancellationToken = default(CancellationToken));
    }
}