// -----------------------------------------------------------------------
// <copyright file="ISkuDownloadOptions.cs" company="Microsoft">
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
    /// Defines the behavior of the SKU's download options.
    /// </summary>
    public interface ISkuDownloadOptions : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<SkuDownloadOptions, ResourceCollection<SkuDownloadOptions>>
    {
    }
}
