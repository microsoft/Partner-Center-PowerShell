// -----------------------------------------------------------------------
// <copyright file="PSBaseAzureDataMarketLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Groups the common properties for all types of Azure data market invoice line items.
    /// </summary>
    public abstract class PSBaseAzureDataMarketLineItem : PSInvoiceLineItem
    {
        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public override BillingProvider BillingProvider => BillingProvider.AzureDataMarket;

        /// <summary>
        /// Gets or sets the date charge ends.
        /// </summary>
        public DateTime ChargeEndDate { get; set; }

        /// <summary>
        /// Gets or sets the date charge begins.
        /// </summary>
        public DateTime ChargeStartDate { get; set; }

        /// <summary>
        /// Gets or sets the total units consumed.
        /// </summary>
        public decimal ConsumedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the customer company name.
        /// </summary>
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the partner's azure active directory tenant Id.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier.
        /// </summary>
        /// <remarks>
        /// For direct reseller, this is the partner's MPN identifier.
        /// For indirect reseller, this is the VAR's MPN identifier.
        /// </remarks>
        public int PartnerMpnId { get; set; }

        /// <summary>
        /// Gets or sets the partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets the region associated with the resource instance.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the resource name. 
        /// </summary>
        /// <remarks>
        /// Example: Database (GB/month).
        /// </remarks>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the service name. 
        /// </summary>
        /// <remarks>
        /// Example: Azure Data Service.
        /// </remarks>
        public string ServiceName { get; set; }

        /// <summary>
        /// Gets or sets the description of the subscription.
        /// </summary>
        public string SubscriptionDescription { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the subscription name.
        /// </summary>
        public string SubscriptionName { get; set; }
    }
}