// -----------------------------------------------------------------------
// <copyright file="AzureUtilizationRecord.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Utilizations
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A utilization record for an Azure subscription resource.
    /// </summary>
    public sealed class AzureUtilizationRecord : ResourceBase
    {
        /// <summary>
        /// Gets or sets the key-value pairs of instance-level details.
        /// </summary>
        public IDictionary<string, string> InfoFields { get; private set; }

        /// <summary>
        /// Gets or sets the instance details.
        /// </summary>
        public AzureInstanceData InstanceData { get; set; }

        /// <summary>
        /// Gets or sets the quantity consumed of the Azure resource.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Azure resource which was used.
        /// </summary>
        public AzureResource Resource { get; set; }

        /// <summary>
        /// Gets or sets the type of quantity (hours, bytes, etc...).
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the end of the usage aggregation time range.
        /// The response is grouped by the time of consumption (when the resource was actually used VS. when was it reported to the billing system).
        /// </summary>
        public DateTimeOffset UsageEndTime { get; set; }

        /// Gets or sets the start of the usage aggregation time range.
        /// The response is grouped by the time of consumption (when the resource was actually used VS. when was it reported to the billing system).
        /// </summary>
        public DateTimeOffset UsageStartTime { get; set; }
    }
}