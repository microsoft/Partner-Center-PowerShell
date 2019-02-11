// -----------------------------------------------------------------------
// <copyright file="OrderLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// An order line item associates order information to a specific offer of a product.
    /// </summary>
    public sealed class OrderLineItem : ResourceBaseWithLinks<OrderLineItemLinks>
    {
        /// <summary>
        /// Gets or sets the line item number.
        /// </summary>
        public int LineItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the resulting subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription identifier.
        /// This parameter should only be set for add-on offer purchase. This applies to Order updates only.
        /// </summary>
        public string ParentSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the result contract (subscription).
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier on record.
        /// </summary>
        public string PartnerIdOnRecord { get; set; }

        /// <summary>
        /// Gets or sets the provisioning context for the offer.
        /// </summary>
        public Dictionary<string, string> ProvisioningContext { get; set; }
    }
}
