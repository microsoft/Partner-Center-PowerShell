// -----------------------------------------------------------------------
// <copyright file="CustomerLicensesInsightsBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Analytics
{
    /// <summary>
    /// Model for common properties of customer licenses analytics.
    /// </summary>
    public abstract class CustomerLicensesInsightsBase : LicensesInsightsBase
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the product/plan name of the given service. (Example: OFFICE 365 BUSINESS ESSENTIALS).
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Service Code of the License. Example (Office 365 : O365).
        /// </summary>
        public string ServiceCode { get; set; }
    }
}