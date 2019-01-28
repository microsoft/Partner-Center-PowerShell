// -----------------------------------------------------------------------
// <copyright file="ParticipantType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Carts
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Types of Participants
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ParticipantType
    {
        /// <summary>
        /// Default value if not known.
        /// </summary>
        Unknown,

        /// <summary>
        /// An indirect reseller with a transaction role.
        /// </summary>
        TransactionReseller,
    }
}