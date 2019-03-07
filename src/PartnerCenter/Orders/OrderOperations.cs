// -----------------------------------------------------------------------
// <copyright file="OrderOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Orders;

    /// <summary>
    /// The order operations implementation class.
    /// </summary>
    internal class OrderOperations : BasePartnerComponent<Tuple<string, string>>, IOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        public OrderOperations(IPartner rootPartnerOperations, string customerId, string orderId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, orderId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
        }

        /// <summary>
        /// Gets the order provisioning status operations.
        /// </summary>
        public IOrderProvisioningStatus ProvisioningStatus => new OrderProvisioningStatusOperations(Partner, Context.Item1, Context.Item2);

        /// <summary>
        /// Gets the customer order.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer order.</returns>
        public async Task<Order> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<Order>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrder.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Patches the specified customer order.
        /// </summary>
        /// <param name="order">The order to be patched.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated order.</returns>
        public async Task<Order> PatchAsync(Order entity, CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.PatchAsync<Order, Order>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateOrder.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
