// -----------------------------------------------------------------------
// <copyright file="ResourceUsageRecordCollectionOperations.cs" company="Microsoft">
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
    using Models.JsonConverters;
    using Models.Usage;

    /// <summary>
    /// Implements operations related to a single subscription resource usage records.
    /// </summary>
    internal class ResourceUsageRecordCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IResourceUsageRecordCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceUsageRecordCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifer.</param>
        /// <param name="subscriptionId">The subscription identifier.</param>
        public ResourceUsageRecordCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Retrieves the subscription usage records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of subscription usage records.</returns>
        public ResourceCollection<AzureResourceMonthlyUsageRecord> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves the subscription usage records.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of subscription usage records.</returns>
        public async Task<ResourceCollection<AzureResourceMonthlyUsageRecord>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<AzureResourceMonthlyUsageRecord>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSubscriptionResourceUsageRecords.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<AzureResourceMonthlyUsageRecord>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}