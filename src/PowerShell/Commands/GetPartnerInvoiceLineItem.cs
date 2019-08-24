// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;
    using PartnerCenter.PowerShell.Models.Invoices;

    /// <summary>
    /// Gets a list of line items for the specified invoice from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceLineItem"), OutputType(typeof(PSInvoiceLineItem))]
    public class GetPartnerInvoiceLineItem : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the billing provider.
        /// </summary>
        [Parameter(HelpMessage = "The billing provide for the line items.", Mandatory = true)]
        [ValidateSet(nameof(BillingProvider.Azure), nameof(BillingProvider.Office), nameof(BillingProvider.OneTime), nameof(BillingProvider.Marketplace))]
        public BillingProvider BillingProvider { get; set; }

        /// <summary>
        /// Gets or sets the currenty code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code for the unbilled line items.", Mandatory = false)]
        [ValidateNotNull]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or set the identifier for the invoice.
        /// </summary>
        [Parameter(HelpMessage = "The identifier corresponding to the invoice.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the invoice line item type.
        /// </summary>
        [Parameter(HelpMessage = "The type of invoice line items.", Mandatory = true)]
        [ValidateSet(nameof(InvoiceLineItemType.BillingLineItems), nameof(InvoiceLineItemType.UsageLineItems))]
        public InvoiceLineItemType LineItemType { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IResourceCollectionEnumerator<ResourceCollection<InvoiceLineItem>> enumerator;
            List<InvoiceLineItem> items;
            ResourceCollection<InvoiceLineItem> lineItems;

            if (BillingProvider == BillingProvider.Marketplace)
            {
                lineItems = Partner.Invoices[InvoiceId].By(BillingProvider, LineItemType, CurrencyCode, BillingPeriod.Current).GetAsync().GetAwaiter().GetResult();
            }
            else
            {
                lineItems = Partner.Invoices[InvoiceId].By(BillingProvider, LineItemType).GetAsync().GetAwaiter().GetResult();
            }

            enumerator = Partner.Enumerators.InvoiceLineItems.Create(lineItems);
            items = new List<InvoiceLineItem>();

            while (enumerator.HasValue)
            {
                items.AddRange(enumerator.Current.Items);
                enumerator.NextAsync().GetAwaiter().GetResult();
            }

            if (LineItemType == InvoiceLineItemType.BillingLineItems)
            {
                if (BillingProvider == BillingProvider.Azure)
                {
                    WriteObject(items.Select(i => new PSUsageBasedLineItem((UsageBasedLineItem)i)), true);
                }
                else if (BillingProvider == BillingProvider.Office)
                {
                    WriteObject(items.Select(i => new PSLicenseBasedLineItem((LicenseBasedLineItem)i)), true);
                }
                else if (BillingProvider == BillingProvider.OneTime)
                {
                    WriteObject(items.Select(i => new PSOneTimeInvoiceLineItem((OneTimeInvoiceLineItem)i)), true);
                }
                else if (BillingProvider == BillingProvider.Marketplace)
                {
                    WriteObject(items.Select(i => new PSDailyRatedUsageLineItem((DailyRatedUsageLineItem)i)), true);
                }
            }
            else
            {
                if (BillingProvider == BillingProvider.Azure)
                {
                    WriteObject(items.Select(i => new PSDailyUsageLineItem((DailyUsageLineItem)i)), true);
                }
                else if (BillingProvider == BillingProvider.Marketplace)
                {
                    WriteObject(items.Select(i => new PSDailyRatedUsageLineItem((DailyRatedUsageLineItem)i)), true);
                }
            }
        }
    }
}