// -----------------------------------------------------------------------
// <copyright file="TaxReceipt.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using System;

    /// <summary>
    /// Represents the tax receipt details.
    /// </summary>
    public sealed class TaxReceipt
    {
        /// <summary>
        /// Gets or sets the tax receipt unique identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the tax receipt download link.
        /// </summary>
        public Uri TaxReceiptPdfDownloadLink { get; set; }
    }
}
