// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using Extensions;
    using PartnerCenter.Models.Usage;

    /// <summary>
    /// Defines the monthly usage record of a customer for all its subscriptions.
    /// </summary>
    public sealed class PSCustomerMonthlyUsageRecord : PSUsageRecordBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerUsageSummary" /> class.
        /// </summary>
        public PSCustomerMonthlyUsageRecord()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerMonthlyUsageRecord" /> class.
        /// </summary>
        /// <param name="resource">The base resource for the instance.</param>
        public PSCustomerMonthlyUsageRecord(CustomerMonthlyUsageRecord resource)
        {
            this.CopyFrom(resource, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the spending budget allocated for the customer.
        /// </summary>
        public PSSpendingBudget Budget { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer's Azure subscription was upgraded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this customer's Azure subscription was upgraded; otherwise, <c>false</c>.
        /// </value>
        public bool IsUpgraded { get; set; }

        /// <summary>
        /// Gets or sets the percentage used out of the allocated budget.
        /// </summary>
        public decimal PercentUsed { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="CustomerMonthlyUsageRecord" /> to an instance of <see cref="PSCustomerMonthlyUsageRecord" />. 
        /// </summary>
        /// <param name="resource">The reosurce being cloned.</param>
        private void CloneAdditionalOperations(CustomerMonthlyUsageRecord resource)
        {
            Budget = new PSSpendingBudget(resource.Budget);
        }
    }
}
