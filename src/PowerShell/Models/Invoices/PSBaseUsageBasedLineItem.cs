// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Groups common properties for usage based invoice line items.
    /// </summary>
    public abstract class PSBaseUsageBasedLineItem : PSInvoiceLineItem
    {
        /// <summary>
        /// Gets or sets the Billing cycle type.
        /// </summary>
        public string BillingCycleType { get; set; }

        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public override BillingProvider BillingProvider => BillingProvider.Azure;

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
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the domain name.
        /// </summary>
        public string DomainName { get; set; }

        /// <summary>
        /// Gets or sets the invoice number.
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets the partner's Microsoft Partner Network identifier
        /// </summary>
        /// <remarks>
        /// For direct resellers, this is the MPN Id of the reseller.
        /// For indirect resellers, this is the MPN Id of the VAR (Value Added Reseller).
        /// </remarks>
        public int MpnId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the partner billable account identifier.
        /// </summary>
        public string PartnerBillableAccountId { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the region associated with the resource instance.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the partner name.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Gets or sets the resource identifier.
        /// </summary>
        public string ResourceGuid { get; set; }

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
        /// Gets or sets the service type. 
        /// </summary>
        /// <remarks>
        /// Example: Azure SQL Azure DB.
        /// </remarks>
        public string ServiceType { get; set; }

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

        /// <summary>
        /// Gets or sets the Tier 2 Partner's Microsoft Partner Network identifier.
        /// </summary>
        public int Tier2MpnId { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure for Azure usage.
        /// </summary>
        public string Unit { get; set; }
    }
}