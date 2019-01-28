// -----------------------------------------------------------------------
// <copyright file="Product.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Offers
{
    /// <summary>
    /// Defines a product tied to an offer.
    /// </summary>
    public sealed class Product
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product unit.
        /// </summary>
        public string Unit { get; set; }
    }
}