// -----------------------------------------------------------------------
// <copyright file="BillingProvider.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using Models.JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Different providers of billing information.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum BillingProvider
    {
        None,
        Office,
        Azure,
        AzureDataMarket,
        OneTime,
    }
}