// -----------------------------------------------------------------------
// <copyright file="IProductCollectionByCountryByTargetViewByTargetSegment.cs" company="Microsoft">
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
    /// Holds operations that can be performed on products that belong to a given country, a catalog view and a specific target segment.
    /// </summary>
    public interface IProductCollectionByCountryByTargetViewByTargetSegment : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<Product, ResourceCollection<Product>>
    {
    }
}