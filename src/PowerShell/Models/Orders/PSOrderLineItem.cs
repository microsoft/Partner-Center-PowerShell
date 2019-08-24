// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Orders
{
    using System.Collections;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// An order line item associates order information to a specific offer of a product.
    /// </summary>
    public sealed class PSOrderLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrderLineItem" /> class.
        /// </summary>
        public PSOrderLineItem()
        {
            ProvisioningContext = new Hashtable();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrderLineItem" /> class.
        /// </summary>
        /// <param name="orderLineItem">The base order line item for this instance.</param>
        public PSOrderLineItem(OrderLineItem orderLineItem)
        {
            ProvisioningContext = new Hashtable();
            this.CopyFrom(orderLineItem, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the friendly name for the result contract (subscription).
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the line item number.
        /// </summary>
        public int LineItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier on record.
        /// </summary>
        public string PartnerIdOnRecord { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription identifier.
        /// </summary>
        /// <remarks>
        /// This parameter should only be set for add-on offer purchase. This applies to Order updates only.
        /// </remarks>
        public string ParentSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the pricing for the order.
        /// </summary>
        /// <remarks>
        /// This information will not be returned unless explicitly requested. 
        /// </remarks>
        public Pricing Pricing { get; set; }

        /// <summary>
        /// Gets the provisioning context for the offer.
        /// </summary>
        public Hashtable ProvisioningContext { get; }

        /// <summary>
        /// Gets or sets the product quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the resulting subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets the term duration.
        /// </summary>
        public string TermDuration { get; private set; }

        /// <summary>
        /// Gets the transaction type.
        /// </summary>
        public string TransactionType { get; private set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="OrderLineItem" /> to an instance of <see cref="PSOrderLineItem" />. 
        /// </summary>
        /// <param name="lineItem">An instance of the <see cref="OrderLineItem" /> class that will serve as base for this instance.</param>
        private void CloneAdditionalOperations(OrderLineItem lineItem)
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