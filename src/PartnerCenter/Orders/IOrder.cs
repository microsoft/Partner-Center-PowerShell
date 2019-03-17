// -----------------------------------------------------------------------
// <copyright file="IOrder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models.Orders;

    /// <summary>
    /// Encapsulates a customer order behavior.
    /// </summary>
    public interface IOrder : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<Order>, IEntityPatchOperations<Order>
    {
        /// <summary>
        /// Gets the line item collection operations.
        /// </summary>
        IOrderLineItemCollection OrderLineItems { get; }

        /// <summary>
        /// Gets the order provisioning status operations.
        /// </summary>
        IOrderProvisioningStatus ProvisioningStatus { get; }

        /// <summary>
        /// Gets the order information.
        /// </summary>
        /// <param name="includePrice">A flag indicating whether to include pricing details in the order information or not.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The order information including pricing details (based on access permissions) when requested.</returns>
        Task<Order> GetAsync(bool includePrice, CancellationToken cancellationToken = default);
    }
}
