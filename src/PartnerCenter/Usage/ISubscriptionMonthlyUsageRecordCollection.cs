// -----------------------------------------------------------------------
// <copyright file="ISubscriptionMonthlyUsageRecordCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using GenericOperations;
    using Models;
    using Models.Usage;

    /// <summary>
    /// Defines the behavior for a customer's subscription usage records.
    /// </summary>
    public interface ISubscriptionMonthlyUsageRecordCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<SubscriptionMonthlyUsageRecord, ResourceCollection<SubscriptionMonthlyUsageRecord>>
    {
    }
}