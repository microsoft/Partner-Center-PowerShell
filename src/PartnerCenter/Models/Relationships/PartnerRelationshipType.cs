// -----------------------------------------------------------------------
// <copyright file="PartnerRelationshipType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Relationships
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// The types of relationships between partners for two tier partner scenario.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum PartnerRelationshipType
    {
        /// <summary>
        /// An indirect reseller relationship between partners.
        /// </summary>
        IsIndirectResellerOf,

        /// <summary>
        /// An indirect cloud solution provider relationship between partners.
        /// </summary>
        IsIndirectCloudSolutionProviderOf
    }
}