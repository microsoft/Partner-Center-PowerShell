// -----------------------------------------------------------------------
// <copyright file="Offer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Offers
{
    using Newtonsoft.Json;

    /// <summary>
    /// Bundles offer links.
    /// </summary>
    public sealed class OfferLinks : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the learn more link.
        /// </summary>
        [JsonProperty]
        public Link LearnMore { get; set; }
    }
}