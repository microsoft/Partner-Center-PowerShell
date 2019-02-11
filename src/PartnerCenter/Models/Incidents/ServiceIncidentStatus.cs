// -----------------------------------------------------------------------
// <copyright file="ServiceIncidentStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Incidents
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the status of Partner Center services.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ServiceIncidentStatus
    {
        /// <summary>
        /// Default status - normal.
        /// </summary>
        Normal,

        /// <summary>
        /// Informational status.
        /// </summary>
        Information,
        
        /// <summary>
        /// Warning status.
        /// </summary>
        Warning,
        
        /// <summary>
        /// Critical status.
        /// </summary>
        Critical
    }
}