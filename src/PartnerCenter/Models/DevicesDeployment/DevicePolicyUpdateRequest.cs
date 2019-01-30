// -----------------------------------------------------------------------
// <copyright file="DevicePolicyUpdateRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the list of devices to be updated with a policy.
    /// </summary>
    public sealed class DevicePolicyUpdateRequest : ResourceBase
    {
        /// <summary>
        /// Gets or sets the list of devices to be updated.
        /// </summary>
        public IEnumerable<Device> Devices { get; set; }
    }
}