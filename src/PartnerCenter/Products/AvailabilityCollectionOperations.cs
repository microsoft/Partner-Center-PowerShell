// -----------------------------------------------------------------------
// <copyright file="AvailabilityCollectionOperations.cs" company="Microsoft">
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
    /// Availabilities implementation class.
    /// </summary>
    internal class AvailabilityCollectionOperations : BasePartnerComponent<Tuple<string, string, string>>, IAvailabilityCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilityCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The corresponding product id.</param>
        /// <param name="skuId">The corresponding sku id.</param>
        /// <param name="country">The country on which to base the product.</param>
        public AvailabilityCollectionOperations(IPartner rootPartnerOperations, string productId, string skuId, string country)
          : base(rootPartnerOperations, new Tuple<string, string, string>(productId, skuId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the operations tied with a specific availability.
        /// </summary>
        /// <param name="id">The identifier of the availability.</param>
        /// <returns>The available availability operations.</returns>

        public IAvailability this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific availability.
        /// </summary>
        /// <param name="id">The identifier of the availability.</param>
        /// <returns>The available availability operations.</returns>
        public IAvailability ById(string id)
        {
            return new AvailabilityOperations(Partner, Context.Item1, Context.Item2, id, Context.Item3);
        }

        /// <summary>
        /// Gets the operations that can be applied on availabilities filtered by a specific target segment.
        /// </summary>
        /// <param name="targetSegment">The availability segment filter.</param>
        /// <returns>The availability collection operations by target segment.</returns>
        public IAvailabilityCollectionByTargetSegment ByTargetSegment(string targetSegment)
        {
            return new AvailabilityCollectionByTargetSegmentOperations(Partner, Context.Item1, Context.Item2, Context.Item3, targetSegment);
        }

        /// <summary>
        /// Gets the availabilities for the provided SKU.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The availabilities for the provided SKU.</returns>
        public async Task<ResourceCollection<Availability>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetAvailabilities.Parameters.Country,
                    Context.Item3
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Availability>>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAvailabilities.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Availability>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}