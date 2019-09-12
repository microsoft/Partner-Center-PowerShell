// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// The subscription provisioning status details.
    /// </summary>
    public sealed class PSSubscriptionProvisioningStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscriptionProvisioningStatus" /> class.
        /// </summary>
        public PSSubscriptionProvisioningStatus()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscriptionProvisioningStatus" /> class.
        /// </summary>
        /// <param name="status">The base subscription provisioning status for this instance.</param>
        public PSSubscriptionProvisioningStatus(SubscriptionProvisioningStatus status)
        {
            this.CopyFrom(status);
        }

        /// <summary>
        /// Gets or sets the end  date.
        /// </summary>
        /// <remarks>
        /// Renewal or end date after provisioning.
        /// </remarks>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        /// <remarks>
        ///  Latest seat number or subscription quantity after provisioning.
        /// </remarks>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the subscription SKU identifier.
        /// </summary>
        public Guid SkuId { get; set; }

        /// <summary>
        /// Gets or sets the subscription provisioning status.
        /// </summary>
        public ProvisioningStatus Status { get; set; }
    }
}