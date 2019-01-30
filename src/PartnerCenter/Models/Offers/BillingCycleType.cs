// -----------------------------------------------------------------------
// <copyright file="BillingCycleType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Offers
{
    using JsonConverters;
    using Newtonsoft.Json;

    [JsonConverter(typeof(EnumJsonConverter))]
    public enum BillingCycleType
    {
        Unknown,
        Monthly,
        Annual,
        None,
        OneTime,
    }
}