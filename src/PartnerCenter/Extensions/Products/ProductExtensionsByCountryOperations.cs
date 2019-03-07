// -----------------------------------------------------------------------
// <copyright file="ProductExtensionsByCountryOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions.Products
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.Products;

    /// <summary>
    /// Product extensions operations implementation by country.
    /// </summary>
    internal class ProductExtensionsByCountryOperations : BasePartnerComponent<string>, IProductExtensionsByCountry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductExtensionsByCountryOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="country">The country on which to base the corresponding products.</param>
        public ProductExtensionsByCountryOperations(IPartner rootPartnerOperations, string country)
          : base(rootPartnerOperations, country)
        {
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets inventory validation results for the provided country.
        /// </summary>
        /// <param name="checkRequest">The request for the inventory check.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The inventory check results.</returns>
        public async Task<IEnumerable<InventoryItem>> CheckInventoryAsync(InventoryCheckRequest checkRequest, CancellationToken cancellationToken = default)
        {
            checkRequest.AssertNotNull(nameof(checkRequest));

            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.CheckInventory.Parameters.Country,
                    Context
                },
            };

            return await Partner.ServiceClient.PostAsync<InventoryCheckRequest, IEnumerable<InventoryItem>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.CheckInventory.Path}",
                    UriKind.Relative),
                checkRequest,
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
