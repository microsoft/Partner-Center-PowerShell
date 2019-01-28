// -----------------------------------------------------------------------
// <copyright file="ISkuCollection.cs" company="Microsoft">
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
    /// Holds operations that can be performed on SKUs.
    /// </summary>
    public interface ISkuCollection : IPartnerComponent<Tuple<string, string>>, IEntitySelector<ISku>, IEntireEntityCollectionRetrievalOperations<Sku, ResourceCollection<Sku>>
    {
        /// <summary>
        /// Gets the operations that can be applied on skus that belong to a segment.
        /// </summary>
        /// <param name="targetSegment">The sku segment filter.</param>
        /// <returns>The sku collection operations by target segment.</returns>
        ISkuCollectionByTargetSegment ByTargetSegment(string targetSegment);
    }
}