// -----------------------------------------------------------------------
// <copyright file="InvoiceLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a line item on an invoice.
    /// </summary>
    [JsonConverter(typeof(InvoiceLineItemConverter))]
    public abstract class InvoiceLineItem : ResourceBase
    {
        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public abstract InvoiceLineItemType InvoiceLineItemType { get; }

        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public abstract BillingProvider BillingProvider { get; }
    }
}
