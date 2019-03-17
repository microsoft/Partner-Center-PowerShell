// -----------------------------------------------------------------------
// <copyright file="ISubscriptionActivationLinkCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Orders;

    /// <summary>
    /// Represents the subscription activation link opreations.
    /// </summary>
    public interface ISubscriptionActivationLinkCollection : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<ResourceCollection<OrderLineItemActivationLink>>
    {
    }
}