// -----------------------------------------------------------------------
// <copyright file="IDeviceCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using System.Collections.Generic;
    using GenericOperations;
    using Models;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's devices.
    /// </summary>
    public interface IDeviceCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Device, ResourceCollection<Device>>, IEntityCreateOperations<IEnumerable<Device>, string>, IEntitySelector<string, IDevice>
    {
    }
}