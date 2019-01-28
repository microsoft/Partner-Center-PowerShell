// -----------------------------------------------------------------------
// <copyright file="AzureMeter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.RateCards
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a meter included in an Azure rate card.
    /// </summary>
    public sealed class AzureMeter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureMeter" /> class.
        /// </summary>
        public AzureMeter()
        {
            Rates = new Dictionary<decimal, decimal>();
        }

        /// <summary>
        /// Gets or sets the category of the meter.
        /// </summary>
        /// <remarks>
        /// Example: Storage.
        /// </remarks>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the date this meter is in effect (in UTC).
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the meter unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the included quantity which is free of charge.
        /// </summary>
        public decimal IncludedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the  name of the meter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the meter rates. The dictionary key is the meter quantity and the value is the meter rate.
        /// </summary>
        public Dictionary<decimal, decimal> Rates { get; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the subcategory of the meter.
        /// </summary>
        /// <remarks>
        /// Example: SKU.
        /// </remarks>
        public string Subcategory { get; set; }

        /// <summary>
        /// Gets or sets the Azure meter tags.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the base unit for the rates.
        /// </summary>
        public string Unit { get; set; }
    }
}
