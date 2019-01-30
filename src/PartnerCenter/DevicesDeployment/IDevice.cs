// -----------------------------------------------------------------------
// <copyright file="IDevice.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using GenericOperations;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's device.
    /// </summary>
    public interface IDevice : IPartnerComponent<Tuple<string, string, string>>, IEntityPatchOperations<Device>, IEntityDeleteOperations<Device>
    {
    }
}