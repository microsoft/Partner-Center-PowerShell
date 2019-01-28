// -----------------------------------------------------------------------
// <copyright file="QuantityProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    /// <summary>
    /// Represents the quantity provisioning status.
    /// </summary>
    public class QuantityProvisioningStatus : ResourceBase
    {
        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets provisioning status.
        /// </summary>
        public string Status { get; set; }
    }
}