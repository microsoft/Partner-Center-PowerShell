// -----------------------------------------------------------------------
// <copyright file="UserState.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Users
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// The possible states for a user.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum UserState
    {
        /// <summary>
        /// Active user
        /// </summary>
        Active,

        /// <summary>
        /// Inactive user
        /// </summary>
        Inactive
    }
}