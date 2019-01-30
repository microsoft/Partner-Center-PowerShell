// -----------------------------------------------------------------------
// <copyright file="IBatchJobStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using GenericOperations;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's Batch Upload Status.
    /// </summary>
    public interface IBatchJobStatus : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<BatchUploadDetails>
    {
    }
}