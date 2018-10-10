// -----------------------------------------------------------------------
// <copyright file="PSCustomerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using Common;
    using PartnerCenter.Models.Usage;

    /// <summary>
    /// Defines the usage summary for a specific customer.
    /// </summary>
    public sealed class PSCustomerUsageSummary : PSUsageSummaryBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerUsageSummary" /> class.
        /// </summary>
        public PSCustomerUsageSummary()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerUsageSummary" /> class.
        /// </summary>
        /// <param name="summary">The base summary for the instance.</param>
        public PSCustomerUsageSummary(CustomerUsageSummary summary)
        {
            this.CopyFrom(summary, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the spending budget allocated to the customer.
        /// </summary>
        public PSSpendingBudget Budget { get; set; }

        /// <summary>
        /// Gets or sets the azure active directory tenant Id of the customer which this usage summary applies to.
        /// </summary>
        public new string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer which this usage summary applies to.
        /// </summary>
        public new string ResourceName { get; set; }

        /// <summary>
        /// Addtional operations to be performed when cloning an instance of <see cref="CustomerUsageSummary" /> to an instance of <see cref="PSCustomerUsageSummary" />. 
        /// </summary>
        /// <param name="customerUsageSummary">The cart being cloned.</param>
        private void CloneAdditionalOperations(CustomerUsageSummary summary)
        {
            Budget = new PSSpendingBudget(summary.Budget);
        }
    }
}