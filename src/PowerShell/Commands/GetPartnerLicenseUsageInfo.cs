// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Analytics;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// Get partner licenses usage information aggregated to include all customers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerLicenseUsageInfo"), OutputType(typeof(PSPartnerLicensesUsageInsight))]
    public class GetPartnerLicenseUsageInfo : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<PartnerLicensesUsageInsights> insights = Partner.Analytics.Licenses.Usage.GetAsync().GetAwaiter().GetResult();
            WriteObject(insights.Items.Select(l => new PSPartnerLicensesUsageInsight(l)), true);
        }
    }
}