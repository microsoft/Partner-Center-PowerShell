// -----------------------------------------------------------------------
// <copyright file="CartErrorCode.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Carts
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>Types of cart error code.</summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum CartErrorCode
    {
        /// <summary>
        /// Default value
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Currency is not supported for given market.
        /// </summary>
        CurrencyIsNotSupported = 10000,

        /// <summary>
        /// Catalog item identifier is not valid.
        /// </summary>
        CatalogItemIdIsNotValid = 10001,

        /// <summary>
        /// Not enough quota available.
        /// </summary>
        QuotaNotAvailable = 10002,

        /// <summary>
        /// Inventory is not available for selected offer.
        /// </summary>
        InventoryNotAvailable = 10003,

        /// <summary>
        /// Setting participants is not supported for partner.
        /// </summary>
        ParticipantsIsNotSupportedForPartner = 10004,

        /// <summary>
        /// Unable to process cart line item.
        /// </summary>
        UnableToProcessCartLineItem = 10006,

        /// <summary>
        /// Subscription is not valid.
        /// </summary>
        SubscriptionIsNotValid = 10007,

        /// <summary>
        /// Subscription is not enabled for RI purchase.
        /// </summary>
        SubscriptionIsNotEnabledForRI = 10008,

        /// <summary>
        /// The sandbox limit has been exceeded.
        /// </summary>
        SandboxLimitExceeded = 10009,

        /// <summary>
        /// Generic input is not valid.
        /// </summary>
        InvalidInput = 10010,
    }
}