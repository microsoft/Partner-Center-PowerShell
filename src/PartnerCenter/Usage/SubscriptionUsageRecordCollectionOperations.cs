// -----------------------------------------------------------------------
// <copyright file="SubscriptionUsageRecordCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using Extensions;

    /// <summary>
    /// Implementation class for subscription usage record collection operations.
    /// </summary>
    internal class SubscriptionUsageRecordCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISubscriptionUsageRecordCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionUsageRecordCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public SubscriptionUsageRecordCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Gets the subscription usage records grouped by days.
        /// </summary>
        public ISubscriptionDailyUsageRecordCollection Daily => new SubscriptionDailyUsageRecordCollectionOperations(Partner, Context.Item1, Context.Item2);

        /// <summary>
        /// Gets the subscription usage records grouped by resources.
        /// </summary>
        public IResourceUsageRecordCollection Resources => new ResourceUsageRecordCollectionOperations(Partner, Context.Item1, Context.Item2);
    }
}