// -----------------------------------------------------------------------
// <copyright file="GetPartnerLicenseDeploymentInfo.cs" company="Microsoft">
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
    /// Get partner licenses deployment information aggregated to include all customers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerLicenseDeploymentInfo"), OutputType(typeof(PSPartnerLicensesDeploymentInsight))]
    public class GetPartnerLicenseDeploymentInfo : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IEnumerable<PartnerLicensesDeploymentInsights> insights;

            try
            {
                insights = Partner.Analytics.Licenses.Deployment.Get().Items;

                WriteObject(insights.Select(l => new PSPartnerLicensesDeploymentInsight(l)), true);
            }
            finally
            {
                insights = null;
            }
        }
    }
}