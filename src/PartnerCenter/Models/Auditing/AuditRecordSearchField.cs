// -----------------------------------------------------------------------
// <copyright file="AuditRecordSearchField.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Auditing
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>Lists the supported audit search fields.</summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum AuditRecordSearchField
    {
        /// <summary
        /// >Customer company name.
        /// </summary>
        CompanyName,

        /// <summary>Customer identifier (Guid).
        /// </summary>
        CustomerId,

        /// <summary>
        /// Resource Type as defined in available Resource Types (Example: Order, Subscription).
        /// </summary>
        ResourceType,
    }
}