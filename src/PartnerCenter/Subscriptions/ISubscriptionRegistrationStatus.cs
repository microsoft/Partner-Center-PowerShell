// -----------------------------------------------------------------------
// <copyright file="ISubscriptionRegistrationStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models.Subscriptions;

    /// <summary>
    /// Defines the operations available on a customer's subscription registration status.
    /// </summary>
    public interface ISubscriptionRegistrationStatus : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<SubscriptionRegistrationStatus>
    {
    }
}