// -----------------------------------------------------------------------
// <copyright file="Device.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a device associated with a customer.
    /// </summary>
    public sealed class Device : ResourceBase
    {
        /// <summary>
        /// Gets or sets the list of HTTP methods allowed on a device as GET, PATCH, DELETE.
        /// </summary>
        public IEnumerable<string> AllowedOperations { get; set; }

        /// <summary>
        /// Gets or sets the hardware hash associated with a device.
        public string HardwareHash { get; set; }

        /// <summary>
        /// Gets or sets the device unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the device model name associated with the device.
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Gets or sets the OEM manufacturer name.
        /// </summary>
        public string OemManufacturerName { get; set; }


        /// <summary>
        /// Gets or sets the list of policies assigned to a device.
        /// </summary>
        public List<KeyValuePair<PolicyCategory, string>> Policies { get; set; }

        /// <summary>
        /// Gets or sets the product key uniquely associated with a device.
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// Gets or sets the serial number associated with a device.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the UTC date the device was uploaded.
        /// </summary>
        public DateTime UploadedDate { get; set; }


    }
}