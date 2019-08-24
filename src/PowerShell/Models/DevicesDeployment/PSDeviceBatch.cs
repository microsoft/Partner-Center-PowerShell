// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Represents a customer's device batch.
    /// </summary>
    public sealed class PSDeviceBatch
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSDeviceBatch" /> class.
        /// </summary>
        public PSDeviceBatch()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSDeviceBatch" /> class.
        /// </summary>
        /// <param name="deviceBatch">The base device batch for this instance.</param>
        public PSDeviceBatch(DeviceBatch deviceBatch)
        {
            this.CopyFrom(deviceBatch, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the list of HTTP methods allowed on a device as GET, PATCH, DELETE.
        /// </summary>
        public IEnumerable<string> AllowedOperations { get; set; }

        /// <summary>
        /// Gets or sets the devices batch unique identifier.
        /// </summary>
        public string BatchId { get; set; }

        /// <summary>
        /// Gets or sets the name of the tenant who created the batch.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date the batch was created.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the count of devices in the batch.
        /// </summary>
        public int DevicesCount { get; set; }

        /// <summary>
        /// Gets or sets the link to the devices under the batch.
        /// </summary>
        public Link DevicesLink { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="DeviceBatch"/> to an instance of <see cref="PSDeviceBatch" />. 
        /// </summary>
        /// <param name="deviceBatch">The device batch being cloned.</param>
        private void CloneAdditionalOperations(DeviceBatch deviceBatch) => BatchId = deviceBatch.Id;
    }
}