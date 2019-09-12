// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Analytics
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Analytics;

    /// <summary>
    /// This resource represents partner's licenses analytics collection.
    /// </summary>
    public class PSLicensesInsightsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicensesInsightsBase" /> class.
        /// </summary>
        public PSLicensesInsightsBase()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicensesInsightsBase" /> class.
        /// </summary>
        /// <param name="insight">The base customer for this instance.</param>
        public PSLicensesInsightsBase(LicensesInsightsBase insight)
        {
            this.CopyFrom(insight);
        }

        /// <summary>
        /// Gets or sets the Channel name of service (Example: Reseller, Direct).
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the Last Processed date for data.
        /// </summary>
        public DateTimeOffset ProcessedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Service name (Example : Office, CRM).
        /// </summary>
        public string ServiceName { get; set; }
    }
}