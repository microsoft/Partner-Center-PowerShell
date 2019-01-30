// -----------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Describes service request severity.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ServiceRequestSeverity
    {
        /// <summary>
        /// Unknown severity.
        /// </summary>
        Unknown,

        /// <summary>
        /// Critical service request impact.
        /// </summary>
        Critical,

        /// <summary>
        /// Moderate service request impact.
        /// </summary>
        Moderate,

        /// <summary>
        /// Minimal service request impact.
        /// </summary>
        Minimal
    }
}