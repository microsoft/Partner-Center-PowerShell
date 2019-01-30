// -----------------------------------------------------------------------
// <copyright file="AzureResourceMonthlyUsageRecord.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Usage
{
    /// <summary>
    /// Defines the monthly usage record for an Azure subscription resource.
    /// </summary>
    public sealed class AzureResourceMonthlyUsageRecord : UsageRecordBase
    {
        /// <summary>
        /// Gets or sets the Azure resource category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the Azure resource sub-category.
        /// </summary>
        public string Subcategory { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the Azure resource used.
        /// </summary>
        public decimal QuantityUsed { get; set; }

        /// <summary>
        /// Gets or sets the estimated total cost of usage for the Azure resource.
        /// </summary>
        public new decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the unit of measure for the Azure resource.
        /// </summary>
        public string Unit { get; set; }
    }
}