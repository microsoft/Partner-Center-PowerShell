// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment
{
    using Extensions;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Represents the status of batch upload of devices.
    /// </summary>
    public sealed class PSDeviceUploadDetails
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSDeviceUploadDetails" /> class.
        /// </summary>
        public PSDeviceUploadDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSDeviceUploadDetails" /> class.
        /// </summary>
        /// <param name="device">The base item for this instance.</param>
        public PSDeviceUploadDetails(DeviceUploadDetails item)
        {
            this.CopyFrom(item);
        }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the error code upon device upload failure.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error description upon device upload failure.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the device upload status.
        /// </summary>
        public DeviceUploadStatusType Status { get; set; }
    }
}