// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Carts
{
    using System.Collections;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Carts;
    using PartnerCenter.Models.Products;

    /// <summary>
    /// Represents a line item on a cart.
    /// </summary>
    public sealed class PSCartLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCartLineItem" /> class.
        /// </summary>
        public PSCartLineItem()
        {
            ProvisioningContext = new Hashtable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCartLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">An instance of the <see cref="CartLineItem" /> class that will serve as a base for this instance.</param>
        public PSCartLineItem(CartLineItem lineItem)
        {
            ProvisioningContext = new Hashtable();
            this.CopyFrom(lineItem, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets a list of items that depend on this one, so they have to be purchased subsequently.
        /// </summary>
        public IEnumerable<CartLineItem> AddonItems { get; set; }

        /// <summary>
        /// Gets or sets the type of billing cycle for the selected catalog item.
        /// </summary>
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the catalog item identifier.
        /// </summary>
        public string CatalogItemId { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets an error associated to this cart line item.
        /// </summary>
        public CartError Error { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the result contract (subscription).
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier of a cart line item.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order group which indicates which items can be place in a single order.
        /// </summary>
        public string OrderGroup { get; set; }

        /// <summary>
        /// Gets or sets a collection of participants on this purchase.
        /// </summary>
        public IEnumerable<KeyValuePair<ParticipantType, string>> Participants { get; set; }

        /// <summary>
        /// Gets a context that will be used for provisioning of the catalog item.
        /// </summary>
        public Hashtable ProvisioningContext { get; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the term duration if applicable.
        /// </summary>
        public string TermDuration { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="CartLineItem" /> to an instance of <see cref="PSCartLineItem" />. 
        /// </summary>
        /// <param name="lineItem">An instance of the <see cref="CartLineItem" /> class that will serve as base for this instance.</param>
        private void CloneAdditionalOperations(CartLineItem lineItem)
        {
            if (lineItem.ProvisioningContext == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> item in lineItem.ProvisioningContext)
            {
                ProvisioningContext.Add(item.Key, item.Value);
            }
        }
    }
}