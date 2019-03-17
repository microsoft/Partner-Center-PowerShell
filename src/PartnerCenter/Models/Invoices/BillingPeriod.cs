// -----------------------------------------------------------------------
// <copyright file="BillingPeriod.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using Models.JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the billing periods.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum BillingPeriod
    {
        /// <summary>
        /// Default period, does not mean anything.
        /// </summary>
        None,

        /// <summary>
        /// The current period that is ongoing.
        /// </summary>
        Current,

        /// <summary>
        /// The previous period.
        /// </summary>
        Previous
    }
}