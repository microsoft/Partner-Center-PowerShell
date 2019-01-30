// -----------------------------------------------------------------------
// <copyright file="CustomerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Usage
{
    /// <summary>
    /// Defines the usage summary for a specific customer.
    /// </summary>
    public sealed class CustomerUsageSummary : UsageSummaryBase
    {
        /// <summary>
        /// Gets or sets the spending budget allocated to the customer.
        /// </summary>
        public SpendingBudget Budget { get; set; }
    }
}