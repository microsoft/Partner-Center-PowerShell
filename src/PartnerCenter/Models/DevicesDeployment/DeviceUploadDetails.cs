// -----------------------------------------------------------------------
// <copyright file="DeviceUploadDetails.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    /// <summary>
    /// Represents the status of batch upload of devices.
    /// </summary>
    public class DeviceUploadDetails : ResourceBase
    {
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