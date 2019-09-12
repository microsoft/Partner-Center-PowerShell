// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment
{
    using System;
    using System.Linq;
    using Extensions;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Represents the result of devices batch upload.
    /// </summary>
    public sealed class PSBatchUploadDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSBatchUploadDetails" /> class.
        /// </summary>
        public PSBatchUploadDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSBatchUploadDetails" /> class.
        /// </summary>
        /// <param name="details">The details for this instance.</param>
        public PSBatchUploadDetails(BatchUploadDetails details)
        {
            this.CopyFrom(details, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the tracking ID of the batch of devices uploaded.
        /// </summary>
        public string BatchTrackingId { get; set; }

        /// <summary>
        /// Gets or sets the batch upload completed time.
        /// </summary>
        public DateTime CompletedTime { get; set; }

        /// <summary>
        /// Gets or sets the device upload status.
        /// </summary>
        public PSDeviceUploadDetails[] DevicesStatus { get; set; }

        /// <summary>
        /// Gets or sets the batch started time.
        /// </summary>
        public DateTime StartedTime { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public DeviceUploadStatusType Status { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="BatchUploadDetails"/> to an instance of <see cref="PSBatchUploadDetails" />. 
        /// </summary>
        /// <param name="item">The item being cloned.</param>
        private void CloneAdditionalOperations(BatchUploadDetails item)
        {
            DevicesStatus = item.DevicesStatus.Select(d => new PSDeviceUploadDetails(d)).ToArray();
        }
    }
}