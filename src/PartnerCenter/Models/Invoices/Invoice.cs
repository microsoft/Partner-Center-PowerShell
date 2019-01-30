// -----------------------------------------------------------------------
// <copyright file="Invoice.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a monthly billing statement issued to a partner.
    /// </summary>
    public sealed class Invoice : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the refernce number of the document which this doc amends.
        /// </summary>
        public string AmendsOf { get; set; }

        /// <summary>
        /// Gets or sets the amendments.
        /// </summary>
        public IEnumerable<Invoice> Amendments { get; set; }

        /// <summary>
        /// Gets or sets the currency used for all invoice item amounts and totals.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol used for all invoice item amounts and totals.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the document type of the invoice (CreditNote, Invoice).
        /// </summary>
        public DocumentType DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the invoice unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the date the invoice was generated.
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the invoice details.
        /// </summary>
        public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }

        /// <summary>
        /// Gets or sets invoice type. 
        /// </summary>
        /// <remarks>
        /// This will be used to set invoice type to Recurring, OneTime for UI to differentiate the types of invoices.
        /// </remarks>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Gets or sets the amount paid by the partner.
        /// </summary>
        /// <remarks>
        /// Paid amount is negative if a payment is received.
        /// </remarks>
        public Decimal PaidAmount { get; set; }

        /// <summary>
        /// Gets or sets the link to download the invoice PDF document.
        /// </summary>
        /// <remarks>
        /// This value is not returned as part of the search results, and will only
        /// get populated if invoice is accessed by Id.
        /// This link auto expires in 30 minutes.
        /// </remarks>
        public Uri PdfDownloadLink { get; set; }

        /// <summary>
        /// Gets or sets the total charges in this invoice.
        /// </summary>
        /// <remarks>
        /// Total charges includes the transactions charges and any adjustments.
        /// </remarks>
        public Decimal TotalCharges { get; set; }
    }
}