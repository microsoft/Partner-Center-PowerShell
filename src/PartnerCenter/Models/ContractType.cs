// -----------------------------------------------------------------------
// <copyright file="ContractType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Describes the type of contract.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum ContractType
    {
        /// <summary>
        /// Refers to a contract which provides subscription for the order item placed
        /// </summary>
        Subscription,

        /// <summary>
        /// Refers to a contract which provides a product key result for the order item placed
        /// </summary>
        ProductKey,

        /// <summary>
        /// Refers to a contract which provides Redemption code result for the order item placed.
        /// </summary>
        RedemptionCode
    }
}