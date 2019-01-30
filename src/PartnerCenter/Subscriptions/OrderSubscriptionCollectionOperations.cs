// -----------------------------------------------------------------------
// <copyright file="OrderSubscriptionCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using GenericOperations;
    using Models;
    using Models.Subscriptions;

    /// <summary>
    /// Implements getting customer subscriptions for a given order.
    /// </summary>
    internal class OrderSubscriptionCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderSubscriptionCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="orderId">The order identifier.</param>
        public OrderSubscriptionCollectionOperations(IPartner rootPartnerOperations, string customerId, string orderId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, orderId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));
        }

        /// <summary>
        /// Gets the subscriptions for the given order.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscriptions associated with the specified order.</returns>
        public ResourceCollection<Subscription> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the subscriptions for the given order.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscriptions associated with the specified order.</returns>
        public async Task<ResourceCollection<Subscription>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerSubscriptionsByOrder.Parameters.OrderId,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Subscription>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSubscriptionsByOrder.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
