// -----------------------------------------------------------------------
// <copyright file="SkuCollectionByTargetSegmentOperations.cs" company="Microsoft">
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
    /// SKU Collection operations implementation.
    /// </summary>
    internal class SkuCollectionByTargetSegmentOperations : BasePartnerComponent<Tuple<string, string, string>>, ISkuCollectionByTargetSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkuCollectionByTargetSegmentOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The product id.</param>
        /// <param name="country">The country on which to base the product.</param>
        /// <param name="targetSegment">The target segment used for filtering the skus.</param>
        public SkuCollectionByTargetSegmentOperations(IPartner rootPartnerOperations, string productId, string country, string targetSegment)
          : base(rootPartnerOperations, new Tuple<string, string, string>(productId, country, targetSegment))
        {
            productId.AssertNotEmpty(nameof(productId));
            country.AssertNotEmpty(nameof(country));
            targetSegment.AssertNotEmpty(nameof(targetSegment));
        }

        /// <summary>
        /// Gets the SKUs for the provided product and target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKUs for the provided product and target segment.</returns>
        public ResourceCollection<Sku> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the SKUs for the provided product and target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKUs for the provided product and target segment.</returns>
        public async Task<ResourceCollection<Sku>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetSkus.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetSkus.Parameters.TargetSegment,
                    Context.Item3
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Sku>>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetSkus.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Sku>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}