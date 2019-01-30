// -----------------------------------------------------------------------
// <copyright file="ISubscriptionSupportContact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using GenericOperations;
    using Models.Subscriptions;

    /// <summary>
    /// Defines the operations available on a customer's subscription support contact.
    /// </summary>
    public interface ISubscriptionSupportContact : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<SupportContact>, IEntityUpdateOperations<SupportContact, SupportContact>
    {
    }
}