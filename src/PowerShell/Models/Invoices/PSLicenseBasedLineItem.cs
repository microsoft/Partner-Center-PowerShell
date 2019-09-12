// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Represents an invoice billing line item for licensed based subscriptions.
    /// </summary>
    public sealed class PSLicenseBasedLineItem : PSInvoiceLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseBasedLineItem" /> class.
        /// </summary>
        public PSLicenseBasedLineItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseBasedLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">The base line item for this instance.</param>
        public PSLicenseBasedLineItem(LicenseBasedLineItem lineItem)
        {
            this.CopyFrom(lineItem);
        }

        /// <summary>
        /// Gets or sets the total amount. Total amount = unit price * quantity.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the billing cycle type.
        /// </summary>
        public string BillingCycleType { get; set; }

        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public override BillingProvider BillingProvider => BillingProvider.Office;

        /// <summary>
        /// Gets or sets the end date for the charge.
        /// </summary>
        public DateTime ChargeEndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date for the charge.
        /// </summary>
        public DateTime ChargeStartDate { get; set; }

        /// <summary>
        /// Gets or sets the type of charge.
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the currency used for this line item.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier..
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets domain name.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets the durable offer unique identifier.
        /// </summary>
        public string DurableOfferId { get; set; }

        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public override InvoiceLineItemType InvoiceLineItemType => InvoiceLineItemType.BillingLineItems;

        /// <summary>
        /// Gets or sets the MPN Id associated to this line item.
        /// </summary>
        /// <remarks>
        /// For direct resellers, this is the MPN Id of the reseller.
        /// For indirect resellers, this is the MPN Id of the VAR (Value Added Reseller).
        /// </remarks>
        public int MpnId { get; set; }

        /// <summary>
        /// Gets or sets the offer unique identifier.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the offer name.
        /// </summary>
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the order unique identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the number of units associated with this line item.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the subscription description.
        /// </summary>
        public string SubscriptionDescription { get; set; }

        /// <summary>
        /// Gets or sets the date when subscription expires.
        /// </summary>
        public DateTime SubscriptionEndDate { get; set; }

        /// <summary>
        /// Gets or sets the subscription unique identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the subscription name.
        /// </summary>
        public string SubscriptionName { get; set; }

        /// <summary>
        /// Gets or sets the date when subscription starts.
        /// </summary>
        public DateTime SubscriptionStartDate { get; set; }

        /// <summary>
        /// Gets or sets the amount after discount.
        /// </summary>
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Gets or sets the syndication partner subscription number.
        /// </summary>
        public string SyndicationPartnerSubscriptionNumber { get; set; }

        /// <summary>
        /// Gets or sets the taxes charged.
        /// </summary>
        public decimal Tax { get; set; }

        /// <summary>
        /// Gets or sets the MPN identifier of the indirect reseller associated to this line item.
        /// </summary>
        public int Tier2MpnId { get; set; }

        /// <summary>
        /// Gets or sets the total amount after discount and tax.
        /// </summary>
        public decimal TotalForCustomer { get; set; }

        /// <summary>
        /// Gets or sets the discount associated with this purchase.
        /// </summary>
        public decimal TotalOtherDiscount { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }
    }
}