// -----------------------------------------------------------------------
// <copyright file="MessageType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceIncidents
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the status of Partner Center services.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum MessageType
    {
        /// <summary>
        /// Default type none.
        /// </summary>
        None,

        /// <summary>
        /// Active incident.
        /// </summary>
        Incident,

        /// <summary>
        /// Message center message.
        /// </summary>
        MessageCenter,

        /// <summary>
        /// All types.
        /// </summary>
        All,
    }
}