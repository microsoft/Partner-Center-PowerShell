// -----------------------------------------------------------------------
// <copyright file="SkuCollectionOperations.cs" company="Microsoft">
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
    internal class SkuCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISkuCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkuCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="country">The country on which to base the product.</param>
        public SkuCollectionOperations(IPartner rootPartnerOperations, string productId, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(productId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the operations tied with a specific SKU.
        /// </summary>
        /// <param name="id">The identifier of the SKU.</param>
        /// <returns>The operations tied with a specific SKU.</returns>
        public ISku this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific SKU.
        /// </summary>
        /// <param name="id">The identifier of the SKU.</param>
        /// <returns>The operations tied with a specific SKU.</returns>
        public ISku ById(string id)
        {
            return new SkuOperations(Partner, Context.Item1, id, Context.Item2);
        }

        /// <summary>
        /// Retrieves the operations that can be applied on skus that belong to a segment.
        /// </summary>
        /// <param name="targetSegment">The sku segment filter.</param>
        /// <returns>The sku collection operations by target segment.</returns>
        public ISkuCollectionByTargetSegment ByTargetSegment(string targetSegment)
        {
            return new SkuCollectionByTargetSegmentOperations(Partner, Context.Item1, Context.Item2, targetSegment);
        }

        /// <summary>
        /// Gets the SKUs for the provided product.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKUs for the provided product.</returns>
        public ResourceCollection<Sku> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets the SKUs for the provided product.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKUs for the provided product.</returns>
        public async Task<ResourceCollection<Sku>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetSkus.Parameters.Country,
                    Context.Item2
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