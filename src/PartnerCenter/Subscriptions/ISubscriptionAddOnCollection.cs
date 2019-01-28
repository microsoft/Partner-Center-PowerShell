// -----------------------------------------------------------------------
// <copyright file="ISubscriptionAddOnCollection.cs" company="Microsoft">
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
    /// Defines the behavior for a subscription's add-ons.
    /// </summary>
    public interface ISubscriptionAddOnCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Subscription, ResourceCollection<Subscription>>
    {
    }
}