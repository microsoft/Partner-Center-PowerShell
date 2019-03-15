// -----------------------------------------------------------------------
// <copyright file="IDevicesBatchCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using GenericOperations;
    using Models;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's devices batches.
    /// </summary>
    public interface IDevicesBatchCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<DeviceBatch, ResourceCollection<DeviceBatch>>, IEntitySelector<string, IDevicesBatch>, IEntityCreateOperations<DeviceBatchCreationRequest, string>
    {
    }
}