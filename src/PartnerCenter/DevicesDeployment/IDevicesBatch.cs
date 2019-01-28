// -----------------------------------------------------------------------
// <copyright file="IDevicesBatch.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;

    /// <summary>
    /// Represents the operations that can be done on the partner's devices batches.
    /// </summary>
    public interface IDevicesBatch : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets the devices behavior of the devices batch.
        /// </summary>
        IDeviceCollection Devices { get; }
    }
}