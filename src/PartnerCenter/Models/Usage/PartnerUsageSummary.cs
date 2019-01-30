// -----------------------------------------------------------------------
// <copyright file="PartnerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Usage
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the usage summary of a partner for all its customers with an Azure subscription.
    /// </summary>
    public sealed class PartnerUsageSummary : UsageSummaryBase
    {
        /// <summary>
        /// Gets or sets the number of customers that are over budget.
        /// </summary>
        public int CustomersOverBudget { get; set; }

        /// <summary>
        /// Gets or sets the number of customers that are close to going over budget.
        /// </summary>
        public int CustomersTrendingOver { get; set; }

        /// <summary>
        /// Gets or sets the number of customers with a usage-based subscription.
        /// </summary>
        public int CustomersWithUsageBasedSubscription { get; set; }

        /// <summary>
        /// Gets or sets the list of email addresses for notifications.
        /// </summary>
        public IEnumerable<string> EmailsToNotify { get; set; }
    }
}