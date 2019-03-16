// -----------------------------------------------------------------------
// <copyright file="Pricing.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    /// <summary>
    /// Represents the pricing details for a line item.
    /// </summary>
    public sealed class Pricing
    {
        /// <summary>
        /// Gets or sets the discounted price.
        /// </summary>
        public double? DiscountedPrice { get; private set; }

        /// <summary>
        /// Gets or sets the extended price.
        /// </summary>
        public double? ExtendedPrice { get; private set; }

        /// <summary>
        /// Gets or sets the list price.
        /// </summary>
        public double? ListPrice { get; private set; }

        /// <summary>
        /// Gets or sets the prorated price.
        /// </summary>
        public double? ProratedPrice { get; private set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double? Price { get; private set; }
    }
}