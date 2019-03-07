// -----------------------------------------------------------------------
// <copyright file="CustomerSkuDownloadOptionsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;
    using PartnerCenter.Products;

    /// <summary>
    /// Implementation of customer sku download options operations.
    /// </summary>
    internal class CustomerSkuDownloadOptionsOperations : BasePartnerComponent<Tuple<string, string, string>>, ISkuDownloadOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSkuDownloadOptionsOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="skuId">The SKU identifier.</param>
        public CustomerSkuDownloadOptionsOperations(
          IPartner rootPartnerOperations,
          string customerId,
          string productId,
          string skuId)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, productId, skuId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
        }

        /// <summary>
        /// Gets all download options for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKU download options.</returns>
        public async Task<ResourceCollection<SkuDownloadOptions>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<SkuDownloadOptions>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSkuDownloadOptions.Path}",
                        Context.Item1,
                        Context.Item2,
                        Context.Item3),
                    UriKind.Relative),
                new ResourceCollectionConverter<SkuDownloadOptions>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}