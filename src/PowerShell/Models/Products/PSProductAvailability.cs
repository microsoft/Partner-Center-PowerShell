// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Products
{
    using Extensions;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Represents a form of product availability to customer.
    /// </summary>
    public sealed class PSProductAvailability
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSProductAvailability" /> class.
        /// </summary>
        public PSProductAvailability()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSProductAvailability" /> class.
        /// </summary>
        /// <param name="productAvailability">The base product availablity for this instance.</param>
        public PSProductAvailability(Availability productAvailability)
        {
            this.CopyFrom(productAvailability, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the unique availability identifier.
        /// </summary>
        public string AvailabilityId { get; set; }

        /// <summary>
        /// Gets or sets the identifier that uniquely identifies this item in the catalog.
        /// </summary>
        public string CatalogItemId { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the default currency code.
        /// </summary>
        public string DefaultCurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the default currency symbol.
        /// </summary>
        public string DefaultCurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the availability is purchasable or not.
        /// </summary>
        public bool IsPurchasable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the availability is renewable or not.
        /// </summary>
        public bool IsRenewable { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the segment.
        /// </summary>
        public string Segment { get; set; }

        /// <summary>
        /// Gets or sets the SKU identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the SKU.
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Availability"/> to an instance of <see cref="PSProductAvailability" />. 
        /// </summary>
        /// <param name="productAvailability">The product availablity being cloned.</param>
        private void CloneAdditionalOperations(Availability productAvailability)
        {
            AvailabilityId = productAvailability.Id;
            DefaultCurrencyCode = productAvailability.DefaultCurrency.Code;
            DefaultCurrencySymbol = productAvailability.DefaultCurrency.Symbol;
        }
    }
}