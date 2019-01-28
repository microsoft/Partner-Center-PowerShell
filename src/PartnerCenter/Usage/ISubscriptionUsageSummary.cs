// -----------------------------------------------------------------------
// <copyright file="ISubscriptionRegistration.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;
    using GenericOperations;
    using Models.Usage;

    /// <summary>
    /// This interface defines the operations available on a customer's subscription usage summary.
    /// </summary>
    public interface ISubscriptionUsageSummary : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<SubscriptionUsageSummary>
    {
    }
}