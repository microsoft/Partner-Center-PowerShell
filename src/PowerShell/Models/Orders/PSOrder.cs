// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// An order is the mean of purchasing offers. Offers are represented by line items within the order.
    /// </summary>
    public sealed class PSOrder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrder" /> class.
        /// </summary>
        public PSOrder()
        {
            LineItems = new List<PSOrderLineItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrder" /> class.
        /// </summary>
        /// <param name="order">The base order for this instance.</param>
        public PSOrder(Order order)
        {
            LineItems = new List<PSOrderLineItem>();
            this.CopyFrom(order, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the type of billing cycle for the selected offers.
        /// </summary>
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the order.
        /// </summary>
        public DateTime? CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the Order line items. Each order line item refers to one offer's purchase data.
        /// </summary>
        public List<PSOrderLineItem> LineItems { get; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the reference customer identifier.
        /// </summary>
        public string ReferenceCustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets the total price for the order.
        /// </summary>
        /// <remarks>
        /// This information will not be returned unless explicitly requested. 
        /// </remarks>
        public double? TotalPrice { get; private set; }

        /// <summary>
        /// Gets the transaction type.
        /// </summary>
        public string TransactionType { get; private set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Order"/> to an instance of <see cref="PSOrder" />. 
        /// </summary>
        /// <param name="order">The order being cloned.</param>
        private void CloneAdditionalOperations(Order order)
        {
            LineItems.AddRange(order.LineItems.Select(o => new PSOrderLineItem(o)));
            OrderId = order.Id;
        }
    }
}