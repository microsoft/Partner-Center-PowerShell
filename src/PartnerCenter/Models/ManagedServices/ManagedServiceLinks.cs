// -----------------------------------------------------------------------
// <copyright file="LicenseAssignment.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ManagedServices
{
    using Newtonsoft.Json;

    /// <summary>
    /// Bundles a Managed service links.
    /// </summary>
    public sealed class ManagedServiceLinks
    {
        /// <summary>
        /// Gets or sets the admin service URI.
        /// </summary>
        [JsonProperty]
        public Link AdminService { get; set; }

        /// <summary>
        /// Gets or sets the service health URI.
        /// </summary>
        [JsonProperty]
        public Link ServiceHealth { get; set; }

        /// <summary>
        /// Gets or sets the service ticket URI.
        /// </summary>
        [JsonProperty]
        public Link ServiceTicket { get; set; }
    }
}