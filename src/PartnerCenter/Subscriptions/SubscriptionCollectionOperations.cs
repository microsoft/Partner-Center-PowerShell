// -----------------------------------------------------------------------
// <copyright file="SubscriptionsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using GenericOperations;
    using Models;
    using Models.Subscriptions;
    using Usage;

    internal class SubscriptionCollectionOperations : BasePartnerComponent<string>, ISubscriptionCollection
    {
        /// <summary>
        /// A lazy reference to the current customer's subscription usage records operations.
        /// </summary>
        private readonly Lazy<ISubscriptionMonthlyUsageRecordCollection> usageRecords;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        public SubscriptionCollectionOperations(IPartner rootPartnerOperations, string customerId)
            : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));

            usageRecords = new Lazy<ISubscriptionMonthlyUsageRecordCollection>((Func<ISubscriptionMonthlyUsageRecordCollection>)(() => (ISubscriptionMonthlyUsageRecordCollection)new SubscriptionMonthlyUsageRecordCollectionOperations(Partner, Context)));
        }

        /// <summary>
        /// Retrieves a specific customer subscription behavior.
        /// </summary>
        /// <param name="id">The subscription identifier.</param>
        /// <returns>The customer subscription behavior.</returns>
        public ISubscription this[string id] => ById(id);

        /// <summary>
        /// Gets the subscription usage records behavior for the customer.
        /// </summary>
        public ISubscriptionMonthlyUsageRecordCollection UsageRecords => usageRecords.Value;

        /// <summary>
        /// Retrieves a specific customer subscription behavior.
        /// </summary>
        /// <param name="id">The subscription identifier.</param>
        /// <returns>The customer subscription.</returns>
        public ISubscription ById(string id)
        {
            return new SubscriptionOperations(Partner, Context, id);
        }

        /// <summary>
        /// Groups customer subscriptions by an order.
        /// </summary>
        /// <param name="orderId">The order identifier.</param>
        /// <returns>The order subscriptions operations.</returns>
        public IEntireEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>> ByOrder(string orderId)
        {
            return new OrderSubscriptionCollectionOperations(Partner, Context, orderId);
        }

        /// <summary>
        /// Groups customer subscriptions by a partner.
        /// </summary>
        /// <param name="partnerId">The partner identifier.</param>
        /// <returns>The partner subscriptions operations.</returns>
        public IEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>> ByPartner(string partnerId)
        {
            return (IEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>>)new PartnerSubscriptionCollectionOperations(Partner, Context, partnerId);
        }

        /// <summary>
        /// Retrieves all subscriptions.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subscriptions that belong to the customer.</returns>

        public async Task<ResourceCollection<Subscription>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<Subscription>>(
                 new Uri(
                     string.Format(
                         CultureInfo.InvariantCulture,
                         $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSubscriptions.Path}",
                         Context),
                     UriKind.Relative),
                 cancellationToken).ConfigureAwait(false);
        }
    }
}