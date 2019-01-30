// -----------------------------------------------------------------------
// <copyright file="IProductCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    /// <summary>
    /// Holds operations that can be performed on products.
    /// </summary>
    public interface IProductCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Retrieves the operations that can be applied on products from a given country.
        /// </summary>
        /// <param name="country">The country name.</param>
        /// <returns>The product collection operations by country.</returns>
        IProductCollectionByCountry ByCountry(string country);
    }
}