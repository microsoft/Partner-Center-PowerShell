// -----------------------------------------------------------------------
// <copyright file="CustomerProductCollectionOperations.cs" company="Microsoft">
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
    using Models.Products;
    using PartnerCenter.Products;

    /// <summary>
    /// Single product by customer identifier operations implementation.
    /// </summary>
    internal class CustomerProductOperations : BasePartnerComponent<Tuple<string, string>>, IProduct
    {
        /// <summary>
        /// Provides the product SKU operations.
        /// </summary>
        private readonly Lazy<ISkuCollection> skus;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProductOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        public CustomerProductOperations(IPartner rootPartnerOperations, string customerId, string productId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, productId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));

            skus = new Lazy<ISkuCollection>(() => new CustomerSkuCollectionOperations(Partner, Context.Item1, Context.Item2));
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
            return await Partner.ServiceClient.GetAsync<Product>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerProduct.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}