// -----------------------------------------------------------------------
// <copyright file="CustomerLicensesDeploymentInsightsCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Analytics;

    /// <summary>
    /// Implements the operations on customer licenses usage insights collection.
    /// </summary>
    internal class CustomerLicensesUsageInsightsCollectionOperations : BasePartnerComponent<string>, ICustomerLicensesUsageInsightsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerLicensesUsageInsightsCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer id of the customer</param>
        public CustomerLicensesUsageInsightsCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
        }

        /// <summary>
        /// Retrieves the collection of customer's licenses' usage insights.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of customer licenses usage insights</returns>
        public ResourceCollection<CustomerLicensesUsageInsights> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves the collection of customer's licenses' usage insights.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Collection of customer licenses usage insights</returns>
        public async Task<ResourceCollection<CustomerLicensesUsageInsights>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<CustomerLicensesUsageInsights>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CustomerLicensesUsageInsights.Path}",
                        Context),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
