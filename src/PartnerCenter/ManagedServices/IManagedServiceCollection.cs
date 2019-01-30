// -----------------------------------------------------------------------
// <copyright file="IManagedServiceCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ManagedServices
{
    using GenericOperations;
    using Models;
    using Models.ManagedServices;

    /// <summary>
    /// Holds the customer's managed services operations.
    /// </summary>
    public interface IManagedServiceCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<ManagedService, ResourceCollection<ManagedService>>
    {
    }
}
