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
    /// Order collection operations implementation class.
    /// </summary>
    internal class OrderCollectionOperations : BasePartnerComponent<string>, IOrderCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public OrderCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets a specific order behavior.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>The order operations.</returns>
        public IOrder this[string id] => ById(id);

        /// <summary>
        /// Gets the order collection behavior given a billing cycle type.
        /// </summary>
        /// <param name="billingCycleType">The billing cycle type.</param>
        /// <returns>The order collection by billing cycle type.</returns>
        public IOrderCollectionByBillingCycleType ByBillingCycleType(BillingCycleType billingCycleType)
        {
            return new OrderCollectionByBillingCycleTypeOperations(Partner, Context, billingCycleType);
        }

        /// <summary>
        /// Gets a specific order behavior.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>The order operations.</returns>
        public IOrder ById(string id)
        {
            return new OrderOperations(Partner, Context, id);
        }

        /// <summary>
        /// Places a new order for the customer.
        /// </summary>
        /// <param name="newOrder">The new order.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The newly created order.</returns>
        public async Task<Order> CreateAsync(Order newEntity, CancellationToken cancellationToken = default)
        {
            newEntity.AssertNotNull(nameof(newEntity));

            return await Partner.ServiceClient.PostAsync<Order, Order>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrders.Path}",
                        Context),
                    UriKind.Relative),
                newEntity,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets all the orders the customer made.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer orders.</returns>
        public async Task<ResourceCollection<Order>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync(false, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a collection of orders.
        /// </summary>
        /// <param name="includePrice">A flag indicating whether to include pricing details in the order information or not.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of orders.</returns>
        public async Task<ResourceCollection<Order>> GetAsync(bool includePrice, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetOrders.Parameters.IncludePrice,
                    includePrice.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Order>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetOrders.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Order>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}