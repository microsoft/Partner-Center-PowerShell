// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Analytics
{
    using Extensions;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// Holds the analytics information about the deployment of all customers' licenses of the given partner.
    /// </summary>
    public sealed class PSPartnerLicensesDeploymentInsight : PSLicensesInsightsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesDeploymentInsight" /> class.
        /// </summary>
        public PSPartnerLicensesDeploymentInsight()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesDeploymentInsight" /> class.
        /// </summary>
        /// <param name="insight">The base customer for this instance.</param>
        public PSPartnerLicensesDeploymentInsight(PartnerLicensesDeploymentInsights insight)
        {
            this.CopyFrom(insight);
        }

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