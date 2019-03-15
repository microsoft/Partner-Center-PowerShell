// -----------------------------------------------------------------------
// <copyright file="IOrderCollectionByBillingCycleType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Offers;
    using Models.Orders;

    /// <summary>
    /// Holds operations that can be performed on orders given a billing cycle type.
    /// </summary>
    public interface IOrderCollectionByBillingCycleType : IPartnerComponent<Tuple<string, BillingCycleType>>, IEntireEntityCollectionRetrievalOperations<Order, ResourceCollection<Order>>
    {
        /// <summary>
        /// Gets all customer orders.
        /// </summary>
        /// <param name="includePrice">A flag indicating whether to include pricing details in the order information or not.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer orders.</returns>
        Task<ResourceCollection<Order>> GetAsync(bool includePrice, CancellationToken cancellationToken = default);
    }
}