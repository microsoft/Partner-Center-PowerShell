// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using Extensions;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Billing line items for usage based subscriptions.
    /// </summary>
    public sealed class PSUsageBasedLineItem : PSBaseUsageBasedLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSUsageBasedLineItem" /> class.
        /// </summary>
        public PSUsageBasedLineItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSUsageBasedLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">The base line item for this instance.</param>
        public PSUsageBasedLineItem(UsageBasedLineItem lineItem)
        {
            this.CopyFrom(lineItem);
        }

        /// <summary>
        /// Gets or sets the charge type.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the discount on consumption.
        /// </summary>
        public decimal ConsumptionDiscount { get; set; }

        /// <summary>
        /// Gets or sets the price of quantity consumed.
        /// </summary>
        public decimal ConsumptionPrice { get; set; }

        /// <summary>
        /// Gets or sets the currency associated with the prices.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the  detail line item identifier.
        /// </summary>
        /// <remarks>
        /// Uniquely identifies the line items for cases where calculation is different for units consumed.
        /// Example: Total consumed = 1338, 1024 is charged with one rate, 314 is charge with a different rate.
        /// </remarks>
        public int DetailLineItemId { get; set; }

        /// <summary>
        /// Gets or sets the units included in the order.
        /// </summary>
        public decimal IncludedQuantity { get; set; }

        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public override InvoiceLineItemType InvoiceLineItemType => InvoiceLineItemType.BillingLineItems;

        /// <summary>
        /// Gets or sets the price of each unit.
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity consumed above allowed usage.
        /// </summary>
        public decimal OverageQuantity { get; set; }

        /// <summary>
        /// Gets or sets the price charged before taxes.
        /// </summary>
        public decimal PretaxCharges { get; set; }

        /// <summary>
        /// Gets or sets the effective price before taxes.
        /// </summary>
        public decimal PretaxEffectiveRate { get; set; }

        /// <summary>
        /// Gets or sets the effective price after taxes.
        /// </summary>
        public decimal PostTaxEffectiveRate { get; set; }

        /// <summary>
        /// Gets or sets the total charges after tax.
        /// </summary>
        /// <remarks>
        /// Pretax Charges + Tax Amount.
        /// </remarks>
        public decimal PostTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the service SKU.
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets the amount of tax charged.
        /// </summary>
        public decimal TaxAmount { get; set; }
    }
}