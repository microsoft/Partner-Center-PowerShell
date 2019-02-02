// -----------------------------------------------------------------------
// <copyright file="GetPartnerLicenseDeploymentInfo.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Authentication;
    using Models.Analytics;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// Get partner licenses deployment information aggregated to include all customers from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerLicenseDeploymentInfo"), OutputType(typeof(PSPartnerLicensesDeploymentInsight))]
    public class GetPartnerLicenseDeploymentInfo : PartnerPSCmdlet
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
            ResourceCollection<PartnerLicensesDeploymentInsights> insights = Partner.Analytics.Licenses.Deployment.Get();
            WriteObject(insights.Items.Select(l => new PSPartnerLicensesDeploymentInsight(l)), true);
        }
    }
}