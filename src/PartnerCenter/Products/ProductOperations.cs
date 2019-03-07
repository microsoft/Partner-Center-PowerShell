// -----------------------------------------------------------------------
// <copyright file="ProductOperations.cs" company="Microsoft">
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
    /// Single product operations implementation.
    /// </summary>
    internal class ProductOperations : BasePartnerComponent<Tuple<string, string>>, IProduct
    {
        /// <summary>
        /// Provides access to the product SKUs operations.
        /// </summary>
        private readonly Lazy<ISkuCollection> skus;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="country">The country on which to base the product.</param>
        public ProductOperations(IPartner rootPartnerOperations, string productId, string country)
          : base(rootPartnerOperations, new Tuple<string, string>(productId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            country.AssertNotEmpty(nameof(country));

            skus = new Lazy<ISkuCollection>(() => new SkuCollectionOperations(rootPartnerOperations, productId, country));
        }

        /// <summary>
        /// Get the SKUs for the product.
        /// </summary>
        public ISkuCollection Skus => skus.Value;

        /// <summary>
        /// Gets the product information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The product information.</returns>
        public async Task<Product> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetProduct.Parameters.Country,
                    Context.Item2
                }
            };

            return await Partner.ServiceClient.GetAsync<Product>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetProduct.Path}",
                        Context.Item1),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
