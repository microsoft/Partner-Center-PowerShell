// -----------------------------------------------------------------------
// <copyright file="IOrderCollectionByBillingCycleType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Offers;
    using Models.Orders;

    /// <summary>
    /// Holds operations that can be performed on orders given a billing cycle type.
    /// </summary>
    public interface IOrderCollectionByBillingCycleType : IPartnerComponent<Tuple<string, BillingCycleType>>, IEntireEntityCollectionRetrievalOperations<Order, ResourceCollection<Order>>
    {
    }
}