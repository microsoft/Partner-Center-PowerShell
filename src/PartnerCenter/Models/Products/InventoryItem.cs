// -----------------------------------------------------------------------
// <copyright file="InventoryItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that represents an inventory item.
    /// </summary>
    public class InventoryItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this item currently has any inventory restrictions.
        /// </summary>
        public bool IsRestricted { get; set; }

        /// <summary>
        /// Gets or sets the item product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the item SKU identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the restrictions for this item if any.
        /// </summary>
        [JsonProperty]
        public IEnumerable<InventoryRestriction> Restrictions { get; set; }
    }
}