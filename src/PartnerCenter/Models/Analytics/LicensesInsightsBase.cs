// -----------------------------------------------------------------------
// <copyright file="LicensesInsightsBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Analytics
{
    using System;

    /// <summary>
    /// Encapsulation of common properties of all licenses' insights.
    /// </summary>
    public abstract class LicensesInsightsBase : ResourceBase
    {
        /// <summary>
        /// Gets or sets the Channel name of service (Example: Reseller, Direct).
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the last processed date for data.
        /// </summary>
        public DateTimeOffset ProcessedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the service name (Example : Office, CRM).
        /// </summary>
        public string ServiceName { get; set; }
    }
}