// -----------------------------------------------------------------------
// <copyright file="ReceiptOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using Extensions;

    /// <summary>
    /// Implements the available receipt operations.
    /// </summary>
    internal class ReceiptOperations : BasePartnerComponent<Tuple<string, string>>, IReceipt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <param name="receiptId">The receipt identifier.</param>
        public ReceiptOperations(IPartner rootPartnerOperations, string invoiceId, string receiptId)
            : base(rootPartnerOperations, new Tuple<string, string>(invoiceId, receiptId))
        {
            invoiceId.AssertNotEmpty(nameof(invoiceId));
            receiptId.AssertNotEmpty(nameof(receiptId));
        }

        /// <summary>
        /// Gets the receipt documents operations.
        /// </summary>
        public IReceiptDocuments Documents => new ReceiptDocumentsOperations(Partner, Context.Item1, Context.Item2);
    }
}