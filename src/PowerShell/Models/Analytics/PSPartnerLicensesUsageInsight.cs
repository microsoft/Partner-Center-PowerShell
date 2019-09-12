// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Analytics
{
    using Extensions;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// This resource represents partner's licenses analytics collection.
    /// </summary>
    public sealed class PSPartnerLicensesUsageInsight : PSLicensesInsightsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesUsageInsight" /> class.
        /// </summary>
        public PSPartnerLicensesUsageInsight()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPartnerLicensesUsageInsight" /> class.
        /// </summary>
        /// <param name="insight">The base insights for this instance.</param>
        public PSPartnerLicensesUsageInsight(PartnerLicensesUsageInsights insight)
        {
            this.CopyFrom(insight);
        }

        /// <summary>
        /// Gets or sets the usage percentage of the given workload out of qualified licenses of all customers of the partner.
        /// </summary>
        public double ProratedLicensesUsagePercent { get; set; }

        /// <summary>
        /// Gets or sets the Workload name. For example: Exchange.
        /// </summary>
        public string WorkloadName { get; set; }
    }
}