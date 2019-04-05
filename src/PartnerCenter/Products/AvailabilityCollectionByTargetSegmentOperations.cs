// -----------------------------------------------------------------------
// <copyright file="AvailabilityCollectionByTargetSegmentOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Products;

    /// <summary>
    /// Availabilities implementation class.
    /// </summary>
    internal class AvailabilityCollectionByTargetSegmentOperations : BasePartnerComponent<Tuple<string, string, string, string>>, IAvailabilityCollectionByTargetSegment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilityCollectionByTargetSegmentOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The corresponding product identifier.</param>
        /// <param name="skuId">The corresponding SKU identifier.</param>
        /// <param name="country">The country on which to base the product.</param>
        /// <param name="targetSegment">The target segment used for filtering the availabilities.</param>
        public AvailabilityCollectionByTargetSegmentOperations(
          IPartner rootPartnerOperations,
          string productId,
          string skuId,
          string country,
          string targetSegment) : base(rootPartnerOperations, new Tuple<string, string, string, string>(productId, skuId, country, targetSegment))
        {
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            country.AssertNotEmpty(nameof(country));
            targetSegment.AssertNotEmpty(nameof(targetSegment));
        }

        /// <summary>
        /// Retrieves all the availabilities for the provided sku on a specific target segment.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availability for the provided sku on a specific target segment.</returns>
        public async Task<ResourceCollection<Availability>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetAvailabilities.Parameters.Country,
                    Context.Item2
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetAvailabilities.Parameters.TargetSegment,
                    Context.Item1
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Availability>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAvailabilities.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Availability>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}
