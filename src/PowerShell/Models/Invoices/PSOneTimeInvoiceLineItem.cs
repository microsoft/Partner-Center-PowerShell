// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Represents an invoice billing line item for OneTime purchases.
    /// </summary>
    public class PSOneTimeInvoiceLineItem : PSInvoiceLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOneTimeInvoiceLineItem" /> class.
        /// </summary>
        public PSOneTimeInvoiceLineItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOneTimeInvoiceLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">The base line item for this instance.</param>
        public PSOneTimeInvoiceLineItem(OneTimeInvoiceLineItem lineItem)
        {
            this.CopyFrom(lineItem);
        }

        /// <summary>
        /// Gets or sets the alternate identifier (quote identifier).
        /// </summary>
        public string AlternateId { get; set; }

        /// <summary>
        /// Gets or sets the availability unique identifier.
        /// </summary>
        public string AvailabilityId { get; set; }

        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public override BillingProvider BillingProvider => BillingProvider.OneTime;

        /// <summary>
        /// Gets or sets the charge end date associated with this purchase.
        /// </summary>
        public DateTime ChargeEndDate { get; set; }

        /// <summary>
        /// Gets or sets the charge start date associated with this purchase.
        /// </summary>
        public DateTime ChargeStartDate { get; set; }

        /// <summary>
        /// Gets or sets the type of charge.
        /// Examples: Purchase Fee, Cycle Fee, Prorate Fees when Purchase.
        /// </summary>
        /// <remarks>
        /// Examples: Purchase Fee, Cycle Fee, Prorate Fees when Purchase.
        /// </remarks>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the currency used for this line item.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the customer's country.
        /// </summary>
        public string CustomerCountry { get; set; }

        /// <summary>
        /// Gets or sets the customer domain name.
        /// </summary>
        public string CustomerDomainName { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the discount details associated with this purchase.
        /// </summary>
        public string DiscountDetails { get; set; }

        /// <summary>
        /// Gets or sets the effective unit price.
        /// </summary>
        public decimal EffectiveUnitPrice { get; set; }

        /// <summary>
        /// Gets the the type of invoice line item.
        /// </summary>
        public override InvoiceLineItemType InvoiceLineItemType => InvoiceLineItemType.BillingLineItems;

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the MPN identifier associated to this line item.
        /// </summary>
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the date when order created.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the order unique identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the product unique identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the publisher identifier associated with this purchase.
        /// </summary>
        public string PublisherId { get; set; }

        /// <summary>
        /// Gets or sets the publisher name associated with this purchase.
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        /// Gets or sets the number of units associated with this line item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Reseller MPN identifier of the indirect reseller associated to this line item.
        /// </summary>
        public int ResellerMpnId { get; set; }

        /// <summary>
        /// Gets or sets the SKU unique identifier.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Gets or sets the SKU name.
        /// </summary>
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the subscription description associated with this purchase.
        /// </summary>
        public string SubscriptionDescription { get; set; }

        /// <summary>
        /// Gets or sets the subscription id associated with this purchase.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the amount after discount.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the taxes charged.
        /// </summary>
        public decimal TaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the term and billing cycle associated with this purchase. 
        /// </summary>
        public string TermAndBillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the total amount after discount and tax.
        /// </summary>
        public decimal TotalForCustomer { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        public string UnitType { get; set; }
    }
}