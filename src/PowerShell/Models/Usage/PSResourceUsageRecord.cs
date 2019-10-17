// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Usage
{
    using Extensions;
    using PartnerCenter.Models.Usage;

    /// <summary>
    /// Defines the estimated monetary cost of a subscription's resource level usage in the current billing cycle.
    /// </summary>
    public sealed class PSResourceUsageRecord : PSUsageRecordBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSResourceUsageRecord" /> class.
        /// </summary>
        public PSResourceUsageRecord()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSResourceUsageRecord" /> class.
        /// </summary>
        /// <param name="usageRecord">The base usage record for this instance.</param>
        public PSResourceUsageRecord(ResourceUsageRecord usageRecord)
        {
            this.CopyFrom(usageRecord);
        }

        /// <summary>
        /// Gets or sets the entitlement identifier.
        /// </summary>
        public string EntitlementId { get; set; }

        /// <summary>
        /// Gets or sets the entitlement name.
        /// </summary>
        public string EntitlementName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the resource URI.
        /// </summary>
        public string ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}
