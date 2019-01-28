// -----------------------------------------------------------------------
// <copyright file="ISupportTopicsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using GenericOperations;
    using Models;
    using Models.ServiceRequests;

    /// <summary>
    /// Represents the behavior of support topics.
    /// </summary>
    public interface ISupportTopicsCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<SupportTopic, ResourceCollection<SupportTopic>>
    {
    }
}