// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Analytics;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Analytics;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerLicenseDeploymentInfo"), OutputType(typeof(PSCustomerLicensesDeploymentInsights))]
    public class GetPartnerCustomerLicenseDeploymentInfo : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<CustomerLicensesDeploymentInsights> insights;

            insights = Partner.Customers[CustomerId].Analytics.Licenses.Deployment.GetAsync().GetAwaiter().GetResult();

            WriteObject(insights.Items.Select(i => new PSCustomerLicensesDeploymentInsights(i)), true);
        }
    }
}