// -----------------------------------------------------------------------
// <copyright file="OrderLineItemProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    using System.Collections.Generic;

    /// <summary>
    /// Order line item provisioning status.
    /// </summary>
    public sealed class OrderLineItemProvisioningStatus : ResourceBase
    {
        /// <summary>
        /// Gets or sets the line item number.
        /// </summary>
        public int LineItemNumber { get; set; }

        /// <summary>
        /// Gets or sets quantity provisioning information.
        /// </summary>
        public IEnumerable<QuantityProvisioningStatus> QuantityProvisioningInformation { get; set; }

        /// <summary>
        /// Gets or sets the aggregated state of an order line item.
        /// </summary>
        public string Status { get; set; }
    }
}