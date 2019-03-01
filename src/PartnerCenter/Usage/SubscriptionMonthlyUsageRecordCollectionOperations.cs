// -----------------------------------------------------------------------
// <copyright file="SubscriptionMonthlyUsageRecordCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.Usage;

    /// <summary>
    /// Implements operations related to a single customer's subscription usage records.
    /// </summary>
    internal class SubscriptionMonthlyUsageRecordCollectionOperations : BasePartnerComponent<string>, ISubscriptionMonthlyUsageRecordCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionMonthlyUsageRecordCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public SubscriptionMonthlyUsageRecordCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Retrieves the subscription usage records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of subscription usage records.</returns>
        public async Task<ResourceCollection<SubscriptionMonthlyUsageRecord>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<SubscriptionMonthlyUsageRecord>>(
                 new Uri(
                     string.Format(
                         CultureInfo.InvariantCulture,
                         $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionUsageRecords.Path}",
                         Context),
                     UriKind.Relative),
                 cancellationToken).ConfigureAwait(false);
        }
    }
}
