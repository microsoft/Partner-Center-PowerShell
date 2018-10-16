// -----------------------------------------------------------------------
// <copyright file="PSSubscriptionRegistrationStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions
{
    using Common;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Provides information about the registration status of a subscription.
    /// </summary>
    public sealed class PSSubscriptionRegistrationStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscriptionRegistrationStatus" /> class.
        /// </summary>
        public PSSubscriptionRegistrationStatus()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscriptionRegistrationStatus" /> class.
        /// </summary>
        /// <param name="status">The base subscription provisioning status for this instance.</param>
        public PSSubscriptionRegistrationStatus(SubscriptionRegistrationStatus status)
        {
            this.CopyFrom(status);
        }

        /// <summary>
        /// Gets or sets a GUID formatted string that identifies the subscription.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this subscription is registered.
        /// </summary>
        public string Status { get; set; }
    }
}