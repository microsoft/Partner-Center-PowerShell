// -----------------------------------------------------------------------
// <copyright file="GetPartnerLicenseUsageInfo.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Analytics;
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
        public override void ExecuteCmdlet() { GetLicenseUsageInfo(); }

        /// <summary>
        ///  Get partner licenses usage information aggregated to include all customers from Partner Center..
        /// </summary>
        private void GetLicenseUsageInfo()
        {
            IEnumerable<PartnerLicensesUsageInsights> insights;

            insights = Partner.Analytics.Licenses.Usage.Get().Items;

            WriteObject(insights.Select(l => new PSPartnerLicensesUsageInsight(l)), true);
        }
    }
}