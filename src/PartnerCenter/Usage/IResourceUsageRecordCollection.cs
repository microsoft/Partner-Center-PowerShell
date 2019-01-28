// -----------------------------------------------------------------------
// <copyright file="IResourceUsageRecordCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Usage;

    /// <summary>
    /// Defines the behavior for a subscription's resource usage records.
    /// </summary>
    public interface IResourceUsageRecordCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<AzureResourceMonthlyUsageRecord, ResourceCollection<AzureResourceMonthlyUsageRecord>>
    {
    }
}