// -----------------------------------------------------------------------
// <copyright file="SkuOperations.cs" company="Microsoft">
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
    using Models.Products;

    /// <summary>
    /// Implements a single SKU operations.
    /// </summary>
    internal class SkuOperations : BasePartnerComponent<Tuple<string, string, string>>, ISku
    {
        /// <summary>
        /// Provides access to the availability operations.
        /// </summary>
        private readonly Lazy<IAvailabilityCollection> availabilities;

        /// <summary>Provides access to the SKU download options operations.
        /// </summary>
        private readonly Lazy<ISkuDownloadOptions> downloadOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkuOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="skuId">The SKU identifier.</param>
        /// <param name="country">The country on which to base the sku.</param>
        public SkuOperations(IPartner rootPartnerOperations, string productId, string skuId, string country)
          : base(rootPartnerOperations, new Tuple<string, string, string>(productId, skuId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            country.AssertNotEmpty(nameof(country));

            availabilities = new Lazy<IAvailabilityCollection>(() => new AvailabilityCollectionOperations(rootPartnerOperations, productId, skuId, country));
            downloadOptions = new Lazy<ISkuDownloadOptions>(() => new SkuDownloadOptionsOperations(rootPartnerOperations, productId, skuId, country));
        }

        /// <summary>
        /// Gets the operations for the current SKU's availabilities.
        /// </summary>
        public IAvailabilityCollection Availabilities => availabilities.Value;

        /// <summary>
        /// Gets the operations for the current SKU's download options.
        /// </summary>
        public ISkuDownloadOptions DownloadOptions => downloadOptions.Value;

        /// <summary>
        /// Gets the information for the SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the SKU.</returns>
        public async Task<Sku> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetSku.Parameters.Country,
                    Context.Item3
                }
            };

            return await Partner.ServiceClient.GetAsync<Sku>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSku.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}