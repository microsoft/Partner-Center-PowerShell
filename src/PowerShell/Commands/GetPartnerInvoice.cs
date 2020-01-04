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
    using RequestContext;

    /// <summary>
    /// Gets a list of invoices from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerInvoice")]
    [OutputType(typeof(PSInvoice))]
    public class GetPartnerInvoice : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the invoice identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the invoice.", Mandatory = false)]
        [ValidateNotNull]
        public string InvoiceId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                if (string.IsNullOrEmpty(InvoiceId))
                {
                    IResourceCollectionEnumerator<ResourceCollection<Invoice>> enumerator;
                    List<PSInvoice> invoices;
                    ResourceCollection<Invoice> resources;

                    resources = await partner.Invoices.GetAsync(CancellationToken).ConfigureAwait(false);
                    enumerator = partner.Enumerators.Invoices.Create(resources);

                    invoices = new List<PSInvoice>();

                    while (enumerator.HasValue)
                    {
                        invoices.AddRange(enumerator.Current.Items.Select(i => new PSInvoice(i)));
                        await enumerator.NextAsync(RequestContextFactory.Create(CorrelationId), CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(invoices, true);
                }
                else
                {
                    WriteObject(new PSInvoice(await partner.Invoices[InvoiceId].GetAsync(CancellationToken).ConfigureAwait(false)));
                }
            }, true);
        }
    }
}