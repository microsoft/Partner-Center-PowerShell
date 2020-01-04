// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Invoices;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;

    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceSummary")]
    [OutputType(typeof(PSInvoiceSummary))]
    public class GetPartnerInvoiceSummary : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<InvoiceSummary> summaries = await partner.Invoices.Summaries.GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(summaries.Items.Select(s => new PSInvoiceSummary(s)), true);
            }, true);
        }
    }
}