// -----------------------------------------------------------------------
// <copyright file="ISubscriptionUpgradeCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Subscriptions;

    /// <summary>
    /// This interface defines the upgrade operations available on a customer's subscription.
    /// </summary>
    public interface ISubscriptionUpgradeCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Upgrade, ResourceCollection<Upgrade>>, IEntityCreateOperations<Upgrade, UpgradeResult>
    {
    }
}