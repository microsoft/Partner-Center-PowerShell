// -----------------------------------------------------------------------
// <copyright file="PolicyCategory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.DevicesDeployment
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the policy type that can be assigned to a device.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum PolicyCategory
    {
        /// <summary>
        /// Default settings for the policy.
        /// </summary>
        None,

        /// <summary>
        /// OOBE - Out of box experience policy setting.
        /// </summary>
        OOBE
    }
}