// -----------------------------------------------------------------------
// <copyright file="IProductExtensionsByCountry.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions.Products
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Products;

    /// <summary>
    /// Holds extension operations for products by country.
    /// </summary>
    public interface IProductExtensionsByCountry : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets inventory validation results for the provided country.
        /// </summary>
        /// <param name="checkRequest">The request for the inventory check.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The inventory check results.</returns>
        Task<IEnumerable<InventoryItem>> CheckInventoryAsync(InventoryCheckRequest checkRequest, CancellationToken cancellationToken = default);
    }
}