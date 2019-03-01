// -----------------------------------------------------------------------
// <copyright file="OrderCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Offers;
    using Models.Orders;

    /// <summary>
    /// Order collection by billing cycle type operations implementation class.
    /// </summary>
    internal class OrderCollectionByBillingCycleTypeOperations : BasePartnerComponent<Tuple<string, BillingCycleType>>, IOrderCollectionByBillingCycleType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCollectionByBillingCycleTypeOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="billingCyleType">The billing cycle type.</param>
        public OrderCollectionByBillingCycleTypeOperations(IPartner rootPartnerOperations, string customerId, BillingCycleType billingCyleType)
          : base(rootPartnerOperations, new Tuple<string, BillingCycleType>(customerId, billingCyleType))
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets all customer orders.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The customer orders.</returns>
        public async Task<ResourceCollection<Order>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOrdersByBillingCyleType.Parameters.BillingType,
                    Context.Item2.ToString()
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Order>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrdersByBillingCyleType.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Order>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}