// -----------------------------------------------------------------------
// <copyright file="IBatchJobStatusCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using GenericOperations;

    /// <summary>
    /// Represents the operations that can be done on the partner's batch upload status collection.
    /// </summary>
    public interface IBatchJobStatusCollection : IPartnerComponent<string>, IEntitySelector<string, IBatchJobStatus>
    {
    }
}