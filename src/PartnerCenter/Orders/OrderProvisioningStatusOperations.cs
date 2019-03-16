// -----------------------------------------------------------------------
// <copyright file="OrderProvisioningStatusOperations.cs" company="Microsoft">
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
    using Models;
    using Models.Orders;

    /// <summary>
    /// Implements operations that apply to order provisioning status.
    /// </summary>
    internal class OrderProvisioningStatusOperations : BasePartnerComponent<Tuple<string, string>>, IOrderProvisioningStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderProvisioningStatusOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        public OrderProvisioningStatusOperations(
          IPartner rootPartnerOperations,
          string customerId,
          string orderId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, orderId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
        }

        /// <summary>
        /// Gets the order provisioning status.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The provisioning status for the order.</returns>
        public async Task<ResourceCollection<OrderLineItemProvisioningStatus>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<OrderLineItemProvisioningStatus>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrderProvisioningStatus.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}