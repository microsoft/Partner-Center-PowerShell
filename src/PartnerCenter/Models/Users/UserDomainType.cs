// -----------------------------------------------------------------------
// <copyright file="UserDomainType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Users
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Types of user domains supported.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum UserDomainType
    {
        /// <summary>
        /// Default - None.
        /// </summary>
        None,

        /// <summary>
        /// Password sync directories support mixed mode i.e. users that are cloud only or directory synced from an on premises directory.
        /// </summary>
        Managed,

        /// <summary>
        /// Federated domains don’t support mixed mode. Users created have to be linked to an on premises directory account with their immutable ids.
        /// </summary>
        Federated
    }
}