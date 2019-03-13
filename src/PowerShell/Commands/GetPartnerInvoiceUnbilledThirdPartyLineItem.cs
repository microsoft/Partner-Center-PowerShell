// -----------------------------------------------------------------------
// <copyright file="PartnerInvoiceUnbilledThirdParty.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Authentication;
    using Models.Invoices;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;

    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceUnbilledThirdPartyLineItem")]
    [OutputType(typeof(PSDailyRatedUsageReconLineItem))]
    public class GetPartnerInvoiceUnbilledThirdPartyLineItem : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the currenty code.
        /// </summary>
        [Parameter(HelpMessage = "The currency code for the unbilled line items.", Mandatory = true)]
        [ValidateNotNull]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IResourceCollectionEnumerator<ResourceCollection<InvoiceLineItem>> enumerator;
            List<InvoiceLineItem> items;
            ResourceCollection<InvoiceLineItem> lineItems;

            lineItems = Partner.Invoices["unbilled"].By(BillingProvider.External, InvoiceLineItemType.UsageLineItems, CurrencyCode, UnbilledPeriod.Current).GetAsync().GetAwaiter().GetResult();
            enumerator = Partner.Enumerators.InvoiceLineItems.Create(lineItems);
            items = new List<InvoiceLineItem>();

            while (enumerator.HasValue)
            {
                items.AddRange(enumerator.Current.Items);
                enumerator.NextAsync().GetAwaiter().GetResult();
            }

            WriteObject(items.Select(i => new PSDailyRatedUsageReconLineItem((DailyRatedUsageReconLineItem)i)), true);
        }
    }
}