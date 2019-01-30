// -----------------------------------------------------------------------
// <copyright file="InvoiceSearchField.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Lists the supported invoice search fields.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum InvoiceSearchField
    {
        /// <summary>
        /// The invoice date.
        /// </summary>
        InvoiceDate
    }
}