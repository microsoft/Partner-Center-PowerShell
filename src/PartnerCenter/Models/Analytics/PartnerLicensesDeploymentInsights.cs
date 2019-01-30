// -----------------------------------------------------------------------
// <copyright file="PartnerLicensesDeploymentInsights.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Analytics
{
    /// <summary>
    /// Holds the analytics information about the deployment of all customers' licenses of the given partner.
    /// </summary>
    public sealed class PartnerLicensesDeploymentInsights : LicensesInsightsBase
    {
        /// <summary>
        /// Gets or sets the number of licenses sold as of processed time stamp.
        /// </summary>
        public long LicensesSold { get; set; }

        /// <summary>
        /// Gets or sets the percentage of licenses deployed by all the customers of this partner.
        /// </summary>
        public double ProratedDeploymentPercent { get; set; }
    }
}
