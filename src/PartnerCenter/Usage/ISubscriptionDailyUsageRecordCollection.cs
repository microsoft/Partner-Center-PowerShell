// -----------------------------------------------------------------------
// <copyright file="ISubscriptionDailyUsageRecordCollection.cs" company="Microsoft">
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
    /// Defines the behavior for a subscription's daily usage records.
    /// </summary>
    public interface ISubscriptionDailyUsageRecordCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<SubscriptionDailyUsageRecord, ResourceCollection<SubscriptionDailyUsageRecord>>
    {
    }
}