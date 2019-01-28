// -----------------------------------------------------------------------
// <copyright file="ServiceRequestOrganization.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the supported service request search fields.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ServiceRequestSearchField
    {
        /// <summary>
        /// Service request status.
        /// </summary>
        Status
    }
}