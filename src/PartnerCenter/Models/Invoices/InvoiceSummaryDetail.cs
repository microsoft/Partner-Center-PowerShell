// -----------------------------------------------------------------------
// <copyright file="InvoiceSummaryDetail.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    /// <summary>
    /// Represent a summary of individual details for an invoice type. for example recurring, perpetual.
    /// </summary>
    public sealed class InvoiceSummaryDetail
    {
        /// <summary>
        /// Gets or sets the invoice type. example, recurring, perpetual.
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets summary on Partner's monthly bills for a particular invoice type.
        /// </summary>
        public InvoiceSummary Summary { get; set; }
    }
}