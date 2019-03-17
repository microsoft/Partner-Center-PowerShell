// -----------------------------------------------------------------------
// <copyright file="PSOrderLineItemProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Orders
{
    using System.Collections.Generic;
    using Common;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// Order line item provisioning status.
    /// </summary>
    public sealed class PSOrderLineItemProvisioningStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrderLineItemProvisioningStatus" />
        /// </summary>
        public PSOrderLineItemProvisioningStatus()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrderLineItemProvisioningStatus" />
        /// </summary>
        public PSOrderLineItemProvisioningStatus(OrderLineItemProvisioningStatus status)
        {
            this.CopyFrom(status);
        }

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
