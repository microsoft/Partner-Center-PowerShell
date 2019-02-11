// -----------------------------------------------------------------------
// <copyright file="Artifact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Entitlements
{
    using System.Collections.Generic;
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Class that represents an entitlement artifact.
    /// </summary>
    [JsonConverter(typeof(ArtifactConverter))]
    public class Artifact : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets artifact type.
        /// </summary>
        public string ArtifactType { get; set; }

        /// <summary>
        /// Gets or sets the dynamic attributes.
        /// </summary>
        public Dictionary<string, object> DynamicAttributes { get; private set; }
    }
}