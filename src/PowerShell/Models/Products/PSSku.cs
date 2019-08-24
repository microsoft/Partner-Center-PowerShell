// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Products
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Represents a form of product availability to customer.
    /// </summary>
    public sealed class PSSku
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSku" /> class.
        /// </summary>
        public PSSku()
        {
            DynamicAttributes = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSku" /> class.
        /// </summary>
        /// <param name="sku">The base offer for this instance.</param>
        public PSSku(Sku sku)
        {
            DynamicAttributes = new Dictionary<string, object>();
            this.CopyFrom(sku, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the dynamic attributes.
        /// </summary>
        public Dictionary<string, object> DynamicAttributes { get; }

        /// <summary>
        /// Gets or sets the variables needed for inventory check.
        /// </summary>
        public IEnumerable<string> InventoryVariables { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a trial sku or not.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets the maximum order quantity.
        /// </summary>
        public int MaximumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the minimum order quantity.
        /// </summary>
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the provisioning variables.
        /// </summary>
        public IEnumerable<string> ProvisioningVariables { get; set; }

        /// <summary>
        /// Gets or sets the purchase prerequisites.
        /// </summary>
        public IEnumerable<string> PurchasePrerequisites { get; set; }

        /// <summary>
        /// Gets or sets the SKU identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the billing cycles supported for the offer.
        /// </summary>
        public IEnumerable<BillingCycleType> SupportedBillingCycles { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Sku"/> to an instance of <see cref="PSSku" />. 
        /// </summary>
        /// <param name="sku">The SKU being cloned.</param>
        private void CloneAdditionalOperations(Sku sku)
        {
            if (sku.DynamicAttributes != null)
            {
                foreach (KeyValuePair<string, object> item in sku.DynamicAttributes)
                {
                    DynamicAttributes.Add(item.Key, item.Value);
                }
            }

            SkuId = sku.Id;
        }
    }
}