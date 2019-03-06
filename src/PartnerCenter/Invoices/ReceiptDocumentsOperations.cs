// -----------------------------------------------------------------------
// <copyright file="ReceiptDocumentsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using Extensions;

    /// <summary>
    /// Implements the operations available for receipt documents.
    /// </summary>
    internal class ReceiptDocumentsOperations : BasePartnerComponent<Tuple<string, string>>, IReceiptDocuments
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptDocumentsOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <param name="receiptId">The receipt identifier.</param>
        public ReceiptDocumentsOperations(IPartner rootPartnerOperations, string invoiceId, string receiptId)
            : base(rootPartnerOperations, new Tuple<string, string>(invoiceId, receiptId))
        {
            invoiceId.AssertNotEmpty(nameof(invoiceId));
            receiptId.AssertNotEmpty(nameof(receiptId));
        }

        /// <summary>
        /// Gets an invoice receipt statement operations.
        /// </summary>
        public IReceiptStatement Statement => new ReceiptStatementOperations(Partner, Context.Item1, Context.Item2);
    }
}