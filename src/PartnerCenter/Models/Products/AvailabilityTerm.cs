// -----------------------------------------------------------------------
// <copyright file="AvailabilityTerm.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Products
{
    /// <summary>
    /// Represents an availability term.
    /// </summary>
    public sealed class AvailabilityTerm
    {
        /// <summary>
        /// Gets or sets the ISO standard representation of this term's duration.
        /// </summary>
        /// <remarks>Example: P1M, P1Y, P3Y</remarks>
        public string Duration { get; set; }

        /// <summary>
        /// Gets or sets the term description.
        /// </summary>
        public string Description { get; set; }
    }
}
