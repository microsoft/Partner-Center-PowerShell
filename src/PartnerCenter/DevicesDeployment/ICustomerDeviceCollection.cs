// -----------------------------------------------------------------------
// <copyright file="ICustomerDeviceCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using GenericOperations;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's devices.
    /// </summary>
    public interface ICustomerDeviceCollection : IPartnerComponent<string>, IEntityUpdateOperations<DevicePolicyUpdateRequest, string>
    {
    }
}