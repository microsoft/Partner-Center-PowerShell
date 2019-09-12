// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using Extensions;
    using PartnerCenter.Models.Usage;

    /// <summary>
    /// The spending budget allocated to the customer by the partner.
    /// </summary>
    public sealed class PSSpendingBudget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSpendingBudget" /> class.
        /// </summary>
        public PSSpendingBudget()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSpendingBudget" /> class.
        /// </summary>
        /// <param name="spendingBudget">The base spending budget for this instance.</param>
        public PSSpendingBudget(SpendingBudget spendingBudget)
        {
            this.CopyFrom(spendingBudget);
        }

        /// <summary>
        /// Gets or sets the usage spending budget.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}