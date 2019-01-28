// -----------------------------------------------------------------------
// <copyright file="PartnerRelationshipSearchField.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Relationships
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the supported partner relationship search fields.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum PartnerRelationshipSearchField
    {
        /// <summary>
        /// Partner company name.
        /// </summary>
        Name
    }
}