// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Enumerators;
    using Models.Authentication;
    using Models.Invoices;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Gets unbilled invoice line items from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerUnbilledInvoiceLineItem")]
    [OutputType(typeof(PSOneTimeInvoiceLineItem))]
    [OutputType(typeof(PSDailyRatedUsageLineItem))]
    public class GetPartnerUnbilledInvoiceLineItem : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code for the unbilled line items.", Mandatory = true)]
        [ValidateNotNull]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the type of invoice line items.
        /// </summary>
        [Parameter(HelpMessage = "The type of invoice line items.", Mandatory = true)]
        [ValidateSet(nameof(InvoiceLineItemType.BillingLineItems), nameof(InvoiceLineItemType.UsageLineItems))]
        public InvoiceLineItemType LineItemType { get; set; }

        /// <summary>
        /// Gets or sets the billing period.
        /// </summary>
        [Parameter(HelpMessage = "The billing period for the line items.", Mandatory = true)]
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

                lineItems = await partner.Invoices["Unbilled"].By(BillingProvider.OneTime, LineItemType, CurrencyCode, Period).GetAsync().ConfigureAwait(false);
                enumerator = partner.Enumerators.InvoiceLineItems.Create(lineItems);
                items = new List<InvoiceLineItem>();

                while (enumerator.HasValue)
                {
                    items.AddRange(enumerator.Current.Items);
                    await enumerator.NextAsync().ConfigureAwait(false);
                }

                if (LineItemType == InvoiceLineItemType.BillingLineItems)
                {
                    WriteObject(items.Select(i => new PSOneTimeInvoiceLineItem((OneTimeInvoiceLineItem)i)), true);
                }
                else
                {
                    WriteObject(items.Select(i => new PSDailyRatedUsageLineItem((DailyRatedUsageLineItem)i)), true);
                }

            }, true);
        }
    }
}