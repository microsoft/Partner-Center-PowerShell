// -----------------------------------------------------------------------
// <copyright file="ISkuCollectionByTargetSegment.cs" company="Microsoft">
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
    /// Holds operations that can be performed on skus from a specific target segment.
    /// </summary>
    public interface ISkuCollectionByTargetSegment : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<Sku, ResourceCollection<Sku>>
    {
    }
}