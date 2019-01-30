// -----------------------------------------------------------------------
// <copyright file="SkuDownloadOptionsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;

    /// <summary>
    /// SKU download options operations implementation.
    /// </summary>
    internal class SkuDownloadOptionsOperations : BasePartnerComponent<Tuple<string, string, string>>, ISkuDownloadOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkuDownloadOptionsOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The product id to get its download options.</param>
        /// <param name="skuId">The sku id to get its download options.</param>
        /// <param name="country">The country on which to base the sku.</param>
        public SkuDownloadOptionsOperations(IPartner rootPartnerOperations, string productId, string skuId, string country)
          : base(rootPartnerOperations, new Tuple<string, string, string>(productId, skuId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the download options for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The download options for the provided SKU.</returns>
        public ResourceCollection<SkuDownloadOptions> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the download options for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The download options for the provided SKU.</returns>
        public async Task<ResourceCollection<SkuDownloadOptions>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetSkuDownloadOptions.Parameters.Country,
                    Context.Item3
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<SkuDownloadOptions>>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSkuDownloadOptions.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<SkuDownloadOptions>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}