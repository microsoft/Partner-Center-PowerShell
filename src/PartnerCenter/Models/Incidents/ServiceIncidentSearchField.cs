// -----------------------------------------------------------------------
// <copyright file="ServiceIncidentSearchField.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Incidents
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the supported service incident search fields.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ServiceIncidentSearchField
    {
        /// <summary>
        /// Search by service health incidents resolved status.
        /// </summary>
        Resolved
    }
}