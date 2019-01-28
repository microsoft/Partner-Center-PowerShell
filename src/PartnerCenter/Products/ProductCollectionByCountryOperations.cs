// -----------------------------------------------------------------------
// <copyright file="ProductCollectionByCountryOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using Extensions;

    /// <summary>
    /// Product operations by country implementation class.
    /// </summary>
    internal class ProductCollectionByCountryOperations : BasePartnerComponent<string>, IProductCollectionByCountry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCollectionByCountryOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="country">The country on which to base the products.</param>
        public ProductCollectionByCountryOperations(IPartner rootPartnerOperations, string country)
          : base(rootPartnerOperations, country)
        {
            country.AssertNotEmpty(nameof(country));
        }

        /// <summary>
        /// Gets the operations tied with a specific product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product operations.</returns>
        public IProduct this[string id] => ById(id);

        /// <summary>
        /// Gets the operations tied with a specific product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>The product operations.</returns>
        public IProduct ById(string id)
        {
            return new ProductOperations(Partner, id, Context);
        }

        /// <summary>
        /// Gets the operations that can be applied on products that belong to a given country and catalog view.
        /// </summary>
        /// <param name="targetView">The product target view.</param>
        /// <returns>The product collection operations by country and by target view.</returns>
        public IProductCollectionByCountryByTargetView ByTargetView(string targetView)
        {
            return new ProductCollectionByCountryByTargetViewOperations(Partner, targetView, Context);
        }
    }
}
