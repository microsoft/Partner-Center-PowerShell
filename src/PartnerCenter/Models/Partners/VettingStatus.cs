// -----------------------------------------------------------------------
// <copyright file="VettingStatus.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumeration of vetting status.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum VettingStatus
    {
        /// <summary>
        /// None vetting status
        /// </summary>
        None,

        /// <summary>
        /// Pending vetting status
        /// </summary>
        Pending,

        /// <summary>
        /// Authorized vetting status
        /// </summary>
        Authorized,

        /// <summary>
        /// Rejected vetting status
        /// </summary>
        Rejected
    }
}