// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Invoices;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;
    using RequestContext;

    /// <summary>
    /// Gets a list of line items for the specified invoice from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceLineItem")]
    [OutputType(typeof(PSDailyRatedUsageLineItem))]
    [OutputType(typeof(PSDailyUsageLineItem))]
    [OutputType(typeof(PSLicenseBasedLineItem))]
    [OutputType(typeof(PSOneTimeInvoiceLineItem))]
    [OutputType(typeof(PSUsageBasedLineItem))]
    public class GetPartnerInvoiceLineItem : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the billing provider.
        /// </summary>
        [Parameter(HelpMessage = "The billing provide for the line items.", Mandatory = true)]
        [ValidateSet(nameof(BillingProvider.All), nameof(BillingProvider.Azure), nameof(BillingProvider.Marketplace), nameof(BillingProvider.Office), nameof(BillingProvider.OneTime))]
        public BillingProvider BillingProvider { get; set; }

        /// <summary>
        /// Gets or sets the currenty code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code for the line items.", Mandatory = false)]
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync().ConfigureAwait(false);
                IResourceCollectionEnumerator<ResourceCollection<InvoiceLineItem>> enumerator;
                List<InvoiceLineItem> items;
                ResourceCollection<InvoiceLineItem> lineItems;

                if (BillingProvider == BillingProvider.OneTime || BillingProvider == BillingProvider.Marketplace)
                {
                    lineItems = await partner.Invoices[InvoiceId].By(BillingProvider, LineItemType, CurrencyCode, BillingPeriod.Current).GetAsync(CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    lineItems = await partner.Invoices[InvoiceId].By(BillingProvider, LineItemType).GetAsync(CancellationToken).ConfigureAwait(false);
                }

                enumerator = partner.Enumerators.InvoiceLineItems.Create(lineItems);
                items = new List<InvoiceLineItem>();

                while (enumerator.HasValue)
                {
                    items.AddRange(enumerator.Current.Items);
                    await enumerator.NextAsync(RequestContextFactory.Create(CorrelationId), CancellationToken).ConfigureAwait(false);
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
                    else
                    {
                        WriteObject(items.Select(i => new PSDailyRatedUsageLineItem((DailyRatedUsageLineItem)i)), true);
                    }
                }
            }, true);
        }
    }
}