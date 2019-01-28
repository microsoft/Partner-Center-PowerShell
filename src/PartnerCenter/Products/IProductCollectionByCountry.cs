// -----------------------------------------------------------------------
// <copyright file="IProductCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using GenericOperations;

    /// <summary>
    /// Holds operations that can be performed on products from a given country.
    /// </summary>
    public interface IProductCollectionByCountry : IPartnerComponent<string>, IEntitySelector<IProduct>
    {

        /// <summary>
        /// Retrieves the operations that can be applied on products that belong to a given country and catalog view.
        /// </summary>
        /// <param name="targetView">The product target view.</param>
        /// <returns>The product collection operations by country and by target view.</returns>
        IProductCollectionByCountryByTargetView ByTargetView(string targetView);
    }
}