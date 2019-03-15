// -----------------------------------------------------------------------
// <copyright file="IOrderLineItemActivationLink.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Orders;

    /// <summary>
    /// Represents the customer order line item activation link operations.
    /// </summary>
    public interface IOrderLineItemActivationLink : IPartnerComponent<Tuple<string, string, int>>, IEntityGetOperations<ResourceCollection<OrderLineItemActivationLink>>
    {
    }
}