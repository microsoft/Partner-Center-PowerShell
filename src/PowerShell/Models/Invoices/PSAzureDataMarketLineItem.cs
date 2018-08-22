// -----------------------------------------------------------------------
// <copyright file="PSAzureDataMarketLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using Common;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Defines an Azure Data Market billing line item.
    /// </summary>
    public sealed class PSAzureDataMarketLineItem : PSBaseAzureDataMarketLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureDataMarketLineItem" /> class.
        /// </summary>
        public PSAzureDataMarketLineItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureDataMarketLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">The base line item for this instance.</param>
        public PSAzureDataMarketLineItem(AzureDataMarketLineItem lineItem)
        {
            this.CopyFrom(lineItem);
        }

        /// <summary>
        /// Gets or sets the charge type. 
        /// </summary>
        /// <remarks>
        /// Example: Assess Usage Fee For Current Cycle.
        /// </remarks>
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
        public string CurrencyCode { get; set; }

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
        /// Gets or sets the effective price after taxes.
        /// </summary>
        public decimal PostTaxEffectiveRate { get; set; }

        /// <summary>
        /// Gets or sets the total charges after tax. Pretax Charges + Tax Amount.
        /// </summary>
        public decimal PostTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the price charged before taxes.
        /// </summary>
        public decimal PretaxCharges { get; set; }

        /// <summary>
        /// Gets or sets the effective price before taxes.
        /// </summary>
        public decimal PretaxEffectiveRate { get; set; }

        /// <summary>
        /// Gets or sets the amount of tax charged.
        /// </summary>
        public decimal TaxAmount { get; set; }
    }
}