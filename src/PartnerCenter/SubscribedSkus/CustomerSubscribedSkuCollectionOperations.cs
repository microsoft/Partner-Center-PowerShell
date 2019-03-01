// -----------------------------------------------------------------------
// <copyright file="CustomerSubscribedSkuCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.SubscribedSkus
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Licenses;

    /// <summary>
    /// Customer subscribed products collection operations class.
    /// </summary>
    internal class CustomerSubscribedSkuCollectionOperations : BasePartnerComponent<string>, ICustomerSubscribedSkuCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSubscribedSkuCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerSubscribedSkuCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
        }

        /// <summary>
        /// Gets all the customer subscribed products.
        /// </summary>
        /// <param name="licenseGroupIds">A collection of license group identifiers.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>All the customer subscribed products.</returns>
        public async Task<ResourceCollection<SubscribedSku>> GetAsync(List<LicenseGroupId> licenseGroupIds = null, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (licenseGroupIds != null)
            {
                foreach (LicenseGroupId licenseGroupId in licenseGroupIds)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetCustomerSubscribedSkus.Parameters.LicenseGroupIds,
                        licenseGroupId.ToString());
                }
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<SubscribedSku>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSubscribedSkus.Path}",
                        Context),
                    UriKind.Relative),
                parameters, 
                new ResourceCollectionConverter<SubscribedSku>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}