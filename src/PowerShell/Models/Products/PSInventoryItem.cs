// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Products
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Represents the inventory of a particular product.
    /// </summary>
    public sealed class PSInventoryItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSInventoryItem" /> class.
        /// </summary>
        public PSInventoryItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSInventoryItem" /> class.
        /// </summary>
        /// <param name="item">The base offer for this instance.</param>
        public PSInventoryItem(InventoryItem item)
        {
            this.CopyFrom(item);
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the item sku id.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this item currently has any inventory restrictions.
        /// </summary>
        public bool IsRestricted { get; set; }

        /// <summary>
        /// Gets or sets the restrictions for this item if any.
        /// </summary>
        public IEnumerable<InventoryRestriction> Restrictions { get; set; }
    }
}