// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Analytics
{
    using Extensions;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// Holds analytics information about deployment of licenses at the customer level.
    /// </summary>
    public sealed class PSCustomerLicensesDeploymentInsights : PSCustomerLicensesInsightsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesUsageInsight" /> class.
        /// </summary>
        public PSCustomerLicensesDeploymentInsights()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesUsageInsight" /> class.
        /// </summary>
        /// <param name="insights">The base insights for this instance.</param>
        public PSCustomerLicensesDeploymentInsights(CustomerLicensesDeploymentInsights insights)
        {
            this.CopyFrom(insights);
        }

        /// <summary>
        /// Gets or sets the number of License/seats deployed as of processed date.
        /// </summary>
        public long LicensesDeployed { get; set; }

        /// <summary>
        /// Gets or sets the number of sold seats/licenses as of processed time stamp.
        /// </summary>
        public long LicensesSold { get; set; }

        /// <summary>
        /// Gets or sets the deployment percent of the licenses of the customer.
        /// </summary>
        public double DeploymentPercent { get; set; }
    }
}