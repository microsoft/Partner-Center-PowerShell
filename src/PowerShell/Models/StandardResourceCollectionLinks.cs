// -----------------------------------------------------------------------
// <copyright file="StandardResourceCollectionLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the standard links associated with a resource collection.
    /// </summary>
    public sealed class StandardResourceCollectionLinks : StandardResourceLinks
    {
        /// <summary>
        /// Gets or sets the next page of items.
        /// </summary>
        [JsonProperty]
        public Link Next { get; set; }

        /// <summary>
        /// Gets or sets the previous page of items.
        /// </summary>
        [JsonProperty]
        public Link Previous { get; set; }
    }
}