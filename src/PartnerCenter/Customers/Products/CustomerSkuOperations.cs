// -----------------------------------------------------------------------
// <copyright file="CustomerSkuOperations.cs" company="Microsoft">
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
    /// Implements operations for a single customer SKU.
    /// </summary>
    internal class CustomerSkuOperations : BasePartnerComponent<Tuple<string, string, string>>, ISku
    {
        /// <summary>
        /// Provides the availabilities operations.
        /// </summary>
        private readonly Lazy<IAvailabilityCollection> availabilities;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSkuOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="skuId">The sku identifier.</param>
        public CustomerSkuOperations(IPartner rootPartnerOperations, string customerId, string productId, string skuId)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, productId, skuId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));

            availabilities = new Lazy<IAvailabilityCollection>(() => new CustomerAvailabilityCollectionOperations(Partner, customerId, productId, skuId));
        }

        /// <summary>
        /// Gets the operations for the current SKU's availabilities.
        /// </summary>
        public IAvailabilityCollection Availabilities => availabilities.Value;

        /// <summary>
        /// Gets the SKU information.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The SKU information.</returns>
        public async Task<Sku> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<Sku>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSku.Path}",
                        Context.Item1,
                        Context.Item2, 
                        Context.Item3),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }
    }
}