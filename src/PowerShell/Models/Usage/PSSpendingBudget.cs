// -----------------------------------------------------------------------
// <copyright file="PSSpendingBudget.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    /// <summary>
    /// The spending budget allocated to the customer by the partner.
    /// </summary>
    public sealed class PSSpendingBudget
    {
        /// <summary>
        /// Gets or sets the usage spending budget.
        /// </summary>
        public decimal? Amount { get; set; }
    }
}