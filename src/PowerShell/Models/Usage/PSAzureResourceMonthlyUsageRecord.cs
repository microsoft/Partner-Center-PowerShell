// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using Extensions;
    using PartnerCenter.Models.Usage;

    /// <summary>
    /// Defines the monthly usage record for an Azure subscription resource.
    /// </summary>
    public sealed class PSAzureResourceMonthlyUsageRecord : PSUsageRecordBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureResourceMonthlyUsageRecord" /> class.
        /// </summary>
        public PSAzureResourceMonthlyUsageRecord()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureResourceMonthlyUsageRecord" /> class.
        /// </summary>
        /// <param name="usageRecord">The base usage record for this instance.</param>
        public PSAzureResourceMonthlyUsageRecord(AzureResourceMonthlyUsageRecord usageRecord)
        {
            this.CopyFrom(usageRecord);
        }

        /// <summary>
        /// Gets or sets the Azure resource category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the Azure resource used.
        /// </summary>
        public decimal QuantityUsed { get; set; }

        /// <summary>
        /// Gets or sets the Azure resource unique identifier.
        /// </summary>
        public new string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure resource.
        /// </summary>
        public new string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the Azure resource sub-category.
        /// </summary>
        public string Subcategory { get; set; }

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