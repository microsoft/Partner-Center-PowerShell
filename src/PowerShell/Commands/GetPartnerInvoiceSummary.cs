// -----------------------------------------------------------------------
// <copyright file="GetPartnerInvoiceSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Authentication;
    using Models.Invoices;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;

    [Cmdlet(VerbsCommon.Get, "PartnerInvoiceSummary"), OutputType(typeof(PSInvoiceSummary))]
    public class GetPartnerInvoiceSummary : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<InvoiceSummary> summaries = Partner.Invoices.Summaries.GetAsync().GetAwaiter().GetResult();

            WriteObject(summaries.Items.Select(s => new PSInvoiceSummary(s)), true);
        }
    }
}