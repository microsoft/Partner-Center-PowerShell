// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Represents a summary of the partner's monthly bills.
    /// </summary>
    public sealed class PSInvoiceSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSInvoiceSummary" /> class.
        /// </summary>
        public PSInvoiceSummary()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSInvoiceSummary" /> class.
        /// </summary>
        /// <param name="invoiceSummary">The base invoice summary for this instance.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="invoiceSummary"/> is null.
        /// </exception>
        public PSInvoiceSummary(InvoiceSummary invoiceSummary)
        {
            invoiceSummary.AssertNotNull(nameof(invoiceSummary));

            this.CopyFrom(invoiceSummary);
        }

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