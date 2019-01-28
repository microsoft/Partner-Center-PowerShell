// -----------------------------------------------------------------------
// <copyright file="ProductLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    /// <summary>
    /// Navigation links for product.
    /// </summary>
    public class ProductLinks : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the SKUs link.
        /// </summary>
        public Link Skus { get; set; }
    }
}