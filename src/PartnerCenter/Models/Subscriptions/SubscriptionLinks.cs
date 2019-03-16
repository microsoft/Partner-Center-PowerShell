// -----------------------------------------------------------------------
// <copyright file="SubscriptionLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using Newtonsoft.Json;

    /// <summary>
    /// Bundles links associated with a subscription.
    /// </summary>
    public sealed class SubscriptionLinks : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the activation link.
        /// </summary>
        public Link ActivationLinks { get; set; }

        /// <summary>
        /// Gets or sets the availability link.
        /// </summary>
        public Link Availability { get; set; }

        /// <summary>
        /// Gets or sets the entitlement link.
        /// </summary>
        public Link Entitlement { get; set; }

        /// <summary>
        /// Gets or sets the offer link associated with the subscription.
        /// </summary>
        [JsonProperty]
        public Link Offer { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription link.
        /// </summary>
        [JsonProperty]
        public Link ParentSubscription { get; set; }

        /// <summary>
        /// Gets or sets the product link.
        /// </summary>
        public Link Product { get; set; }

        /// <summary>
        /// Gets or sets the SKU link.
        /// </summary>
        public Link Sku { get; set; }
    }
}