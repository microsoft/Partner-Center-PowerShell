// -----------------------------------------------------------------------
// <copyright file="InventoryCheckRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class that represents an inventory check request.
    /// </summary>
    public sealed class InventoryCheckRequest
    {
        /// <summary>
        /// Any context values that apply towards inventory check of the provided items.
        /// </summary>
        private Dictionary<string, string> inventoryContext;

        /// <summary>
        /// Gets or sets any context values that apply towards inventory check of the provided items.
        /// </summary>
        public Dictionary<string, string> InventoryContext
        {
            get
            {
                if (inventoryContext == null)
                {
                    inventoryContext = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                }

                return inventoryContext;
            }
            set
            {
                inventoryContext = new Dictionary<string, string>(value, StringComparer.OrdinalIgnoreCase);
            }
        }

        /// <summary>
        /// Gets or sets the target items for the inventory check.
        /// </summary>
        public IEnumerable<InventoryItem> TargetItems { get; set; }
    }
}