// -----------------------------------------------------------------------
// <copyright file="InvoiceSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a summary of the partner's monthly bills.
    /// </summary>
    public sealed class InvoiceSummary : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the date the balance amount was last updated.
        /// </summary>
        public DateTime AccountingDate { get; set; }

        /// <summary>
        /// Gets or sets the balance amount. This is the total amount of unpaid bills.
        /// </summary>
        public decimal BalanceAmount { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the balance amount.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol used for all invoice item amounts and totals.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the details include invoice summary from recurring, perpetual.
        /// </summary>
        public IEnumerable<InvoiceSummaryDetail> Details { get; set; }

        /// <summary>
        /// Gets or sets the date on which the first invoice was created.
        /// </summary>
        public DateTime FirstInvoiceCreationDate { get; set; }

        /// <summary>
        /// Gets or sets the last payment amount.
        /// </summary>
        public decimal LastPaymentAmount { get; set; }

        /// <summary>
        /// Gets or sets the last payment date.
        /// </summary>
        public DateTime LastPaymentDate { get; set; }

        /// <summary>
        /// Gets or sets the date of latest invoice.
        /// </summary>
        public DateTime LatestInvoiceDate { get; set; }
    }
}