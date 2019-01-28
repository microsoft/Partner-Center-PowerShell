// -----------------------------------------------------------------------
// <copyright file="IOrderCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using GenericOperations;
    using Models;
    using Models.Offers;
    using Models.Orders;

    /// <summary>
    /// Encapsulates customer orders behavior.
    /// </summary>
    public interface IOrderCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<Order, ResourceCollection<Order>>, IEntityCreateOperations<Order, Order>, IEntitySelector<IOrder>
    {
        /// <summary>
        /// Gets the order collection behavior given a billing cycle type.
        /// </summary>
        /// <param name="billingCycleType">The billing cycle type.</param>
        /// <returns>The order collection by billing cycle type.</returns>
        IOrderCollectionByBillingCycleType ByBillingCycleType(BillingCycleType billingCycleType);
    }
}
