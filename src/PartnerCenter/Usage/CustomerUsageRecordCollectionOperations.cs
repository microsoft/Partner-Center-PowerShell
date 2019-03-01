// -----------------------------------------------------------------------
// <copyright file="CustomerUsageRecordCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Usage;

    /// <summary>
    /// Implements operations related to a partner's customers usage record.
    /// </summary>
    internal class CustomerUsageRecordCollectionOperations : BasePartnerComponent<string>, ICustomerUsageRecordCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerUsageRecordCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public CustomerUsageRecordCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Retrieves the collection of customer monthly usage records for a partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of customer monthly usage records.</returns>
        public async Task<ResourceCollection<CustomerMonthlyUsageRecord>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<CustomerMonthlyUsageRecord>>(
               new Uri(
                   $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerUsageRecords.Path}",
                   UriKind.Relative),
               cancellationToken).ConfigureAwait(false);
        }
    }
}