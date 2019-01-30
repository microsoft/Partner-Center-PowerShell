// -----------------------------------------------------------------------
// <copyright file="IOrder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using GenericOperations;
    using Models.Orders;

    /// <summary>
    /// Encapsulates a customer order behavior.
    /// </summary>
    public interface IOrder : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<Order>, IEntityPatchOperations<Order>
    {
        /// <summary>
        /// Gets the order provisioning status operations.
        /// </summary>
        IOrderProvisioningStatus ProvisioningStatus { get; }
    }
}
