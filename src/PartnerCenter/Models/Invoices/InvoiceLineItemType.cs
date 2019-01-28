// -----------------------------------------------------------------------
// <copyright file="InvoiceLineItemType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using Models.JsonConverters;
    using Newtonsoft.Json;

    /// <summary>Lists invoice line item types.</summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum InvoiceLineItemType
    {
        None,
        UsageLineItems,
        BillingLineItems
    }
}