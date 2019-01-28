// -----------------------------------------------------------------------
// <copyright file="IServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using GenericOperations;
    using Models.ServiceRequests;

    /// <summary>
    /// Groups operations that can be performed on a single service request.
    /// </summary>
    public interface IServiceRequest : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<ServiceRequest>, IEntityPatchOperations<ServiceRequest>
    {
    }
}