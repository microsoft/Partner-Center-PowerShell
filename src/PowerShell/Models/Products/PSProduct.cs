// -----------------------------------------------------------------------
// <copyright file="PSProduct.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Products
{
    using Common;
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
        /// Gets or sets the id.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product type.
        /// </summary>
        public ItemType ProductType { get; set; }

        /// <summary>
        /// Gets or sets the product type name.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Addtional operations to be performed when cloning an instance of <see cref="Product"/> to an instance of <see cref="PSProduct" />. 
        /// </summary>
        /// <param name="product">The product being cloned.</param>
        private void CloneAdditionalOperations(Product product)
        {
            ProductId = product.Id;
            Type = product.ProductType.DisplayName;
        }
    }
}