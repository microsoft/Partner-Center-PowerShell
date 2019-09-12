// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Utilizations
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Utilizations;

    /// <summary>
    /// A utilization record for an Azure subscription resource.
    /// </summary>
    public sealed class PSAzureUtilizationRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureUtilizationRecord" /> class.
        /// </summary>
        public PSAzureUtilizationRecord()
        {
            AdditionalInfo = new Dictionary<string, string>();
            InfoFields = new Dictionary<string, string>();
            Tags = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureUtilizationRecord" /> class.
        /// </summary>
        /// <param name="azureUtilizationRecord">A utilization record for an Azure subscription resource.</param>
        public PSAzureUtilizationRecord(AzureUtilizationRecord azureUtilizationRecord)
        {
            AdditionalInfo = new Dictionary<string, string>();
            InfoFields = new Dictionary<string, string>();
            Tags = new Dictionary<string, string>();

            this.CopyFrom(azureUtilizationRecord, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the the additional info fields.
        /// </summary>
        public IDictionary<string, string> AdditionalInfo { get; }

        /// <summary>
        /// Gets or sets the category of the consumed Azure resource.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the Azure resource that was consumed. Also known as resourceID or resourceGUID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the key-value pairs of instance-level details.
        /// </summary>
        public IDictionary<string, string> InfoFields { get; }

        /// <summary>
        /// Gets or sets the region in which the this service was run.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the Azure resource being consumed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique namespace used to identify the 3rd party order for Azure Marketplace.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique namespace used to identify the resource for Azure Marketplace 3rd party usage.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the quantity consumed of the Azure resource.
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// Gets or sets the region of the consumed Azure resource.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified Azure resource ID, which includes the resource groups and the instance name.
        /// </summary>
        public Uri ResourceUri { get; set; }

        /// <summary>
        /// Gets or sets the sub-category of the consumed Azure resource.
        /// </summary>
        public string Subcategory { get; set; }

        /// <summary>
        /// Gets or the the resource tags specified by the user.
        /// </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary>
        /// Gets or sets the type of quantity (hours, bytes, etc...).
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the end of the usage aggregation time range.
        /// </summary>
        /// <remarks>
        /// The response is grouped by the time of consumption (when the resource was actually used VS. when was it reported to the billing system).
        /// </remarks>
        public DateTimeOffset UsageEndTime { get; set; }

        /// <summary>
        /// Gets or sets the start of the usage aggregation time range.
        /// </summary>
        /// <remarks>
        /// The response is grouped by the time of consumption (when the resource was actually used VS. when was it reported to the billing system).
        /// </remarks>
        public DateTimeOffset UsageStartTime { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="AzureUtilizationRecord" /> to an instance of <see cref="PSAzureUtilizationRecord" />. 
        /// </summary>
        /// <param name="utilizationRecord">The utilization record being cloned.</param>
        private void CloneAdditionalOperations(AzureUtilizationRecord utilizationRecord)
        {
            this.CopyFrom(utilizationRecord?.InstanceData);
            this.CopyFrom(utilizationRecord?.Resource);

            if (utilizationRecord?.InstanceData != null && utilizationRecord.InstanceData.AdditionalInfo != null)
            {
                foreach (KeyValuePair<string, string> item in utilizationRecord.InstanceData.AdditionalInfo)
                {
                    AdditionalInfo.Add(item);
                }
            }

            if (utilizationRecord?.InfoFields != null)
            {
                foreach (KeyValuePair<string, string> item in utilizationRecord.InfoFields)
                {
                    InfoFields.Add(item);
                }
            }

            if (utilizationRecord?.InstanceData != null && utilizationRecord.InstanceData.Tags != null)
            {
                foreach (KeyValuePair<string, string> item in utilizationRecord.InstanceData.Tags)
                {
                    Tags.Add(item);
                }
            }
        }
    }
}