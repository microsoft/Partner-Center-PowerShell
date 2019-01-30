// -----------------------------------------------------------------------
// <copyright file="ISubscriptionProvisioningStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models.Subscriptions;

    /// <summary>
    /// The subscription provisioning status.
    /// </summary>
    public interface ISubscriptionProvisioningStatus : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<SubscriptionProvisioningStatus>
    {
    }
}