// -----------------------------------------------------------------------
// <copyright file="DeviceBatchCreationRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a devices batch creation model.
    /// </summary>
    public sealed class DeviceBatchCreationRequest : ResourceBase
    {
        /// <summary>
        /// Gets or sets the devices batch unique identifier.
        /// </summary>
        public string BatchId { get; set; }

        /// <summary>
        /// Gets or sets the list of devices to be uploaded.
        /// </summary>
        public IEnumerable<Device> Devices { get; set; }
    }
}