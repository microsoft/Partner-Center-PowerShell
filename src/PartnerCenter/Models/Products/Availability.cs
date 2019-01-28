// -----------------------------------------------------------------------
// <copyright file="Availability.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    /// <summary>
    /// Class that represents an availability.
    /// </summary>
    public class Availability : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the unique availability identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the SKU identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the identifier that uniquely identifies this item in the catalog.
        /// </summary>
        public string CatalogItemId { get; set; }

        /// <summary>
        /// Gets or sets the default currency.
        /// </summary>
        public CurrencyInfo DefaultCurrency { get; set; }

        /// <summary>
        /// Gets or sets the segment.
        /// </summary>
        public string Segment { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        public Sku Sku { get; set; }
    }
}
