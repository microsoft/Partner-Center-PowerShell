// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Usage;
    using PartnerCenter.Models.Usage;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUsageSummary"), OutputType(typeof(PSCustomerUsageSummary))]
    public class GetPartnerCustomerUsageSummary : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerUsageSummary summary;

            try
            {
                summary = Partner.Customers[CustomerId].UsageSummary.Get();
                WriteObject(new PSCustomerUsageSummary(summary));
            }
            finally
            {
                summary = null;
            }
        }
    }
}