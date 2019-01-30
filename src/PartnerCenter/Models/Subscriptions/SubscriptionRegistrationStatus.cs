// -----------------------------------------------------------------------
// <copyright file="SubscriptionRegistrationStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// Provides information about the registration status of a subscription.
    /// </summary>
    public class SubscriptionRegistrationStatus : ResourceBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether this subscription is registered.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets a GUID formatted string that identifies the subscription.
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}