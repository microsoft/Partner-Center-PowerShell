// -----------------------------------------------------------------------
// <copyright file="UnbilledPeriod.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using Models.JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents unbilled periods.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum UnbilledPeriod
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
        /// The pervious period.
        /// </summary>
        Previous
    }
}