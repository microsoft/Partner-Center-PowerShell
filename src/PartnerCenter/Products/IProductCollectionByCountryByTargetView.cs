// -----------------------------------------------------------------------
// <copyright file="IProductCollectionByCountryByTargetView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on products that belong to a given country and a catalog view.
    /// </summary>
    public interface IProductCollectionByCountryByTargetView : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Product, ResourceCollection<Product>>
    {
        /// <summary>
        /// Retrieves the operations that can be applied on products that belong to a given country, catalog view and target segment.
        /// </summary>
        /// <param name="targetSegment">The target segment filter.</param>
        /// <returns>The product collection operations by country, by target view and by target segment.</returns>
        IProductCollectionByCountryByTargetViewByTargetSegment ByTargetSegment(string targetSegment);
    }
}