// -----------------------------------------------------------------------
// <copyright file="OrderLineItemLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    using Newtonsoft.Json;

    /// <summary>
    /// Bundles the links for an order line item.
    /// </summary>
    public sealed class OrderLineItemLinks
    {
        /// <summary>
        /// Gets or sets the subscription link for the order line item.
        /// </summary>
        [JsonProperty]
        public Link Subscription { get; set; }

        /// <summary>
        /// Gets or sets the SKU link for the order line item.
        /// </summary>
        [JsonProperty]
        public Link Sku { get; set; }

        /// <summary>
        /// Gets or sets the provisioning status link for the order line item.
        /// </summary>
        [JsonProperty]
        public Link ProvisioningStatus { get; set; }
    }
}