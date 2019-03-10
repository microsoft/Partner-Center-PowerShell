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
        /// <summary>
        /// Initializes for the enum.
        /// </summary>
        None,

        /// <summary>
        /// Bill is provided by Office. Example: O365, and In-tune.
        /// </summary>
        Office,

        /// <summary>
        /// Bill is provided by Azure. Example: Azure Services.
        /// </summary>
        Azure,

        /// <summary>
        /// Bill is provided by Azure Data Market.
        /// </summary>
        AzureDataMarket,

        /// <summary>
        /// Bill is provided for one time purchases.
        /// </summary>
        OneTime,

        /// <summary>
        /// Indicates that the provider is third party       
        /// </summary>
        External,

        /// <summary>
        /// Indicates that the provider is both first party and third party
        /// </summary>
        All
    }
}