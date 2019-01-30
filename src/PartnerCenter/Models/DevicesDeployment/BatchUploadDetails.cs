// -----------------------------------------------------------------------
// <copyright file="BatchUploadDetails.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the result of devices batch upload.
    /// </summary>
    public sealed class BatchUploadDetails : ResourceBase
    {
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
        public IEnumerable<DeviceUploadDetails> DevicesStatus { get; set; }

        /// <summary>
        /// Gets or sets the batch started time.
        /// </summary>
        public DateTime StartedTime { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public DeviceUploadStatusType Status { get; set; }
    }
}
