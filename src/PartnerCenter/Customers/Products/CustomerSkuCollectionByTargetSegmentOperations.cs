// -----------------------------------------------------------------------
// <copyright file="CustomerSkuCollectionByTargetSegmentOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
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
    using PartnerCenter.Products;

    /// <summary>
    /// Implementation of customer sku collection operations by target segment.
    /// </summary>
    internal class CustomerSkuCollectionByTargetSegmentOperations : BasePartnerComponent<Tuple<string, string, string>>, ISkuCollectionByTargetSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerSkuCollectionByTargetSegmentOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="targetSegment">The target segment used for filtering the SKU.</param>
        public CustomerSkuCollectionByTargetSegmentOperations(IPartner rootPartnerOperations, string customerId, string productId, string targetSegment)
          : base(rootPartnerOperations, new Tuple<string, string, string>(customerId, productId, targetSegment))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            productId.AssertNotEmpty(nameof(productId));
            targetSegment.AssertNotEmpty(nameof(targetSegment));
        }

        /// <summary>
        /// Gets all the SKUs for the provided product and target segment.
        /// </summary>
        /// <returns>The SKUs for the provided product and target segment.</returns>
        public ResourceCollection<Sku> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Gets all the SKUs for the provided product and target segment.
        /// </summary>
        /// <returns>The SKUs for the provided product and target segment.</returns>
        public async Task<ResourceCollection<Sku>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetCustomerSkus.Parameters.TargetSegment,
                    Context.Item3
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Sku>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetCustomerSkus.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Sku>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
