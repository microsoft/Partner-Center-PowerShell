// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Analytics
{
    /// <summary>
    /// SDK business object model for common properties of customer licenses analytics.
    /// </summary>
    public abstract class PSCustomerLicensesInsightsBase : PSLicensesInsightsBase
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary
        /// Gets or sets the customer name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the product/plan name of the given service. 
        /// </summary>
        /// <remarks>
        /// (Example: OFFICE 365 BUSINESS ESSENTIALS)
        /// </remarks>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Service Code of the License. 
        /// </summary>
        /// <remarks>
        /// Example (Office 365 : O365)
        /// </remarks>
        public string ServiceCode { get; set; }
    }
}
