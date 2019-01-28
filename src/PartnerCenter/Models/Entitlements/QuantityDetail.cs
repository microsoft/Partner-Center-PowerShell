// -----------------------------------------------------------------------
// <copyright file="QuantityDetail.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Entitlements
{
    /// <summary>
    /// Class that represents a quantity detail.
    /// </summary>
    public class QuantityDetail
    {
        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets status.
        /// </summary>
        public string Status { get; set; }
    }
}