// -----------------------------------------------------------------------
// <copyright file="CartLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Carts
{
    using System.Collections.Generic;
    using Models.Products;

    /// <summary>
    /// Represents a line item on a cart.
    /// </summary>
    public sealed class CartLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CartLineItem" />
        /// </summary>
        public CartLineItem()
        {
            ProvisioningContext = new Dictionary<string, string>();
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
        public Dictionary<string, string> ProvisioningContext { get; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}