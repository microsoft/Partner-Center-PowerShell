// -----------------------------------------------------------------------
// <copyright file="ProductCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    /// <summary>
    /// Product collection operations implementation.
    /// </summary>
    internal class ProductCollectionOperations : BasePartnerComponent<string>, IProductCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public ProductCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the operations that can be applied on products from a given country.
        /// </summary>
        /// <param name="country">The country name.</param>
        /// <returns>The product collection operations by country.</returns>
        public IProductCollectionByCountry ByCountry(string country)
        {
            return new ProductCollectionByCountryOperations(Partner, country);
        }
    }
}