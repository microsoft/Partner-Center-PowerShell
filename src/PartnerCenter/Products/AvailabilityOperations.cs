// -----------------------------------------------------------------------
// <copyright file="AvailabilityOperations.cs" company="Microsoft">
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
    /// Single availability operations implementation.
    /// </summary>
    internal class AvailabilityOperations : BasePartnerComponent<Tuple<string, string, string, string>>, IAvailability
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailabilityOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="productId">The corresponding product identifier.</param>
        /// <param name="skuId">The corresponding SKU identifier.</param>
        /// <param name="availabilityId">The availability identifier.</param>
        /// <param name="country">The country on which to base the availability.</param>
        public AvailabilityOperations(IPartner rootPartnerOperations, string productId, string skuId, string availabilityId, string country)
          : base(rootPartnerOperations, new Tuple<string, string, string, string>(productId, skuId, availabilityId, country))
        {
            productId.AssertNotEmpty(nameof(productId));
            skuId.AssertNotEmpty(nameof(skuId));
            availabilityId.AssertNotEmpty(nameof(availabilityId));
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the information for the availability.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The information for the availability.</returns>
        public async Task<Availability> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetAvailability.Parameters.Country,
                    Context.Item4
                }
            };

            return await Partner.ServiceClient.GetAsync<Availability>(
                new Uri(
                    string.Format(CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAvailability.Path}",
                        Context.Item1, 
                        Context.Item2, 
                        Context.Item3),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
