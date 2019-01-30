// -----------------------------------------------------------------------
// <copyright file="ServiceCostsSummaryLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceCosts
{
    using Newtonsoft.Json;

    /// <summary>
    /// Bundles links with a service costs summary.
    /// </summary>
    public sealed class ServiceCostsSummaryLinks : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the service cost line items.
        /// </summary>
        [JsonProperty]
        public Link ServiceCostLineItems { get; set; }
    }
}