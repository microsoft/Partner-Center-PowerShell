// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;
    using PartnerCenter.PowerShell.Models.Invoices;

    /// <summary>
    /// Gets a list of line items for the specified invoice from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceLineItem", DefaultParameterSetName = ByInvoiceParameterSet)]
    [OutputType(typeof(PSInvoiceLineItem))]
    public class GetPartnerInvoiceLineItem : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Name for the by invoice parameter set.
        /// </summary>
        private const string ByInvoiceParameterSet = "ByInvoice";

        /// <summary>
        /// Name for the by billing period parameter set.
        /// </summary>
        private const string ByBillingPeriodParameterSet = "ByBillingPeriod";

        /// <summary>
        /// Gets or sets the billing provider.
        /// </summary>
        [Parameter(HelpMessage = "The billing provide for the line items.", Mandatory = true, ParameterSetName = ByBillingPeriodParameterSet)]
        [Parameter(HelpMessage = "The billing provide for the line items.", Mandatory = true, ParameterSetName = ByInvoiceParameterSet)]
        [ValidateSet(nameof(BillingProvider.All), nameof(BillingProvider.Azure), nameof(BillingProvider.Office), nameof(BillingProvider.OneTime), nameof(BillingProvider.Marketplace))]
        public BillingProvider BillingProvider { get; set; }

        /// <summary>
        /// Gets or sets the currenty code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code for the unbilled line items.", Mandatory = false, ParameterSetName = ByBillingPeriodParameterSet)]
        [Parameter(HelpMessage = "The currency code for the unbilled line items.", Mandatory = false, ParameterSetName = ByInvoiceParameterSet)]
        [ValidateNotNull]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or set the identifier for the invoice.
        /// </summary>
        [Parameter(HelpMessage = "The identifier corresponding to the invoice.", Mandatory = true, ParameterSetName = ByBillingPeriodParameterSet)]
        [Parameter(HelpMessage = "The identifier corresponding to the invoice.", Mandatory = true, ParameterSetName = ByInvoiceParameterSet)]
        [ValidateNotNullOrEmpty]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the invoice line item type.
        /// </summary>
        [Parameter(HelpMessage = "The type of invoice line items.", Mandatory = true, ParameterSetName = ByBillingPeriodParameterSet)]
        [Parameter(HelpMessage = "The type of invoice line items.", Mandatory = true, ParameterSetName = ByInvoiceParameterSet)]
        [ValidateSet(nameof(InvoiceLineItemType.BillingLineItems), nameof(InvoiceLineItemType.UsageLineItems))]
        public InvoiceLineItemType LineItemType { get; set; }

        /// <summary>
        /// Gets or sets the billing period.
        /// </summary>
        [Parameter(HelpMessage = "The billing period for the line items.", Mandatory = true, ParameterSetName = ByBillingPeriodParameterSet)]
        [ValidateSet(nameof(BillingPeriod.Current), nameof(BillingPeriod.Previous))]
        public BillingPeriod Period { get; set; }

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

                if (ParameterSetName.Equals(ByBillingPeriodParameterSet, StringComparison.InvariantCultureIgnoreCase))
                {
                    lineItems = await partner.Invoices[InvoiceId].By(BillingProvider, LineItemType, CurrencyCode, Period).GetAsync().ConfigureAwait(false);
                }
                else
                {
                    lineItems = await partner.Invoices[InvoiceId].By(BillingProvider, LineItemType).GetAsync().ConfigureAwait(false);
                }

                enumerator = partner.Enumerators.InvoiceLineItems.Create(lineItems);
                items = new List<InvoiceLineItem>();

                while (enumerator.HasValue)
                {
                    items.AddRange(enumerator.Current.Items);
                    await enumerator.NextAsync().ConfigureAwait(false);
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