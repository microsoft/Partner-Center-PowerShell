// -----------------------------------------------------------------------
// <copyright file="IProduct.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on a single product.
    /// </summary>
    public interface IProduct : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<Product>
    {
        /// <summary>
        /// Get the SKUs for the product.
        /// </summary>
        ISkuCollection Skus { get; }
    }
}