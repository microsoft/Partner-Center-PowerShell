// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.DevicesDeployment;

    /// <summary>
    /// Represents a customer device.
    /// </summary>
    public sealed class PSDevice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSDevice" /> class.
        /// </summary>
        public PSDevice()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSDevice" /> class.
        /// </summary>
        /// <param name="item">The base item for this instance.</param>
        public PSDevice(Device item)
        {
            this.CopyFrom(item, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the list of HTTP methods allowed on a device as GET, PATCH, DELETE.
        /// </summary>
        public IEnumerable<string> AllowedOperations { get; set; }

        /// <summary>
        /// Gets or sets the device identifier.
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or sets the hardware hash associated with a device.
        /// </summary>
        public string HardwareHash { get; set; }

        /// <summary>
        /// Gets or sets the model name.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets OEM manufacture name.
        /// </summary>
        public string OemManufacturerName { get; set; }

        /// <summary>
        /// Gets or sets the policies assigned. 
        /// </summary>
        public List<KeyValuePair<PolicyCategory, string>> Policies { get; set; }

        /// <summary>
        /// Gets or sets the product key.
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the serial number.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the UTC date the Device was uploaded.
        /// </summary>
        public DateTime UploadedDate { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Device"/> to an instance of <see cref="PSDevice" />. 
        /// </summary>
        /// <param name="device">The device being cloned.</param>
        private void CloneAdditionalOperations(Device device) => DeviceId = device.Id;
    }
}