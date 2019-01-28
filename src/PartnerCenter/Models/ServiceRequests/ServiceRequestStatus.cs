// -----------------------------------------------------------------------
// <copyright file="ServiceRequestStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Describes service request status.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ServiceRequestStatus
    {
        /// <summary>
        /// Default service request status.
        /// </summary>
        None,

        /// <summary>
        /// An opened service request.
        /// </summary>
        Open,

        /// <summary>
        /// A closed service request.
        /// </summary>
        Closed,

        /// <summary>
        /// A service request that needs attention.
        /// </summary>
        AttentionNeeded
    }
}