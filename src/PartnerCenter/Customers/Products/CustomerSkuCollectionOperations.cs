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
    using Models;
    using Models.JsonConverters;
    using Models.Products;
    using PartnerCenter.Products;

    /// <summary>
    /// Implementation of customer SKU collection operations.
    /// </summary>
    internal class CustomerSkuCollectionOperations : BasePartnerComponent<Tuple<string, string>>, ISkuCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSkuCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        public CustomerSkuCollectionOperations(IPartner rootPartnerOperations, string customerId, string productId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, productId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
        }

        /// <summary>
        /// Gets the operations tied with a specific SKU.
        /// </summary>
        /// <param name="id">The SKU identifier.</param>
        /// <returns>The available SKU operations.</returns>
        public ISku this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific SKU.
        /// </summary>
        /// <param name="id">The SKU identifier.</param>
        /// <returns>The available SKU operations.</returns>
        public ISku ById(string id)
        {
            return new CustomerSkuOperations(Partner, Context.Item1, Context.Item2, id);
        }

        /// <summary>
        /// Gets the operations that can be applied on skus that belong to a segment.
        /// </summary>
        /// <param name="targetSegment">The sku segment filter.</param>
        /// <returns>The sku collection operations by target segment.</returns>
        public ISkuCollectionByTargetSegment ByTargetSegment(string targetSegment)
        {
            return new CustomerSkuCollectionByTargetSegmentOperations(Partner, Context.Item1, Context.Item2, targetSegment);
        }

        /// <summary>
        /// Gets all the SKUs for the provided product.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKUs for the provided product.</returns>
        public async Task<ResourceCollection<Sku>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Sku>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSkus.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                new ResourceCollectionConverter<Sku>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}