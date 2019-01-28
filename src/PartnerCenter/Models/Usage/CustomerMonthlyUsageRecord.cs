// -----------------------------------------------------------------------
// <copyright file="CustomerMonthlyUsageRecord.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Usage
{
    /// <summary>
    /// This class defines the monthly usage record of a customer for all its subscriptions.
    /// </summary>
    public sealed class CustomerMonthlyUsageRecord : UsageRecordBase
    {
        /// <summary>
        /// Gets or sets the spending budget allocated for the customer.
        /// </summary>
        public SpendingBudget Budget { get; set; }

        /// <summary>
        /// Gets or sets the percentage used out of the allocated budget.
        /// </summary>
        public decimal PercentUsed { get; set; }
    }
}