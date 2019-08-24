// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Products
{
    using Extensions;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Represents a form of product availability to customer.
    /// </summary>
    public sealed class PSProduct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSProduct" /> class.
        /// </summary>
        public PSProduct()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSProduct" /> class.
        /// </summary>
        /// <param name="product">The base offer for this instance.</param>
        public PSProduct(Product product)
        {
            this.CopyFrom(product, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a Microsoft product or not.
        /// </summary>
        public bool IsMicrosoftProduct { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Gets or sets the publisher name.
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the produc type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Product"/> to an instance of <see cref="PSProduct" />. 
        /// </summary>
        /// <param name="product">The product being cloned.</param>
        private void CloneAdditionalOperations(Product product)
        {
            ProductId = product.Id;
            Type = product.ProductType.DisplayName;
        }
    }
}