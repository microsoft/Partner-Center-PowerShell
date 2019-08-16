// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Defines the common properties for all usage records.
    /// </summary>
    public abstract class PSUsageRecordBase
    {
        /// <summary>Gets or sets the currency locale.</summary>
        public CultureInfo CurrencyLocale { get; set; }

        /// <summary>
        /// Gets or sets the date the usage record was last modified.
        /// </summary>
        public DateTimeOffset LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the resource unique identifier.
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the estimated total cost of usage.
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}