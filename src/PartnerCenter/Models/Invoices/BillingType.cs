// -----------------------------------------------------------------------
// <copyright file="BillingType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using JsonConverters;
    using Newtonsoft.Json;
    /// <summary>
    /// The way billing is processed for a subscription.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum BillingType
    {
        /// <summary>
        /// Indicates nothing - not set, used as an initializer.
        /// </summary>
        None,

        /// <summary>
        /// Usage based billing.
        /// </summary>
        Usage,

        /// <summary>License based billing.
        /// </summary>
        License
    }
}