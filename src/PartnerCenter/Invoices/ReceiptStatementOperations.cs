// -----------------------------------------------------------------------
// <copyright file="ReceiptDocumentsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;

    /// <summary>
    /// Represents the operations available on an receipt statement.
    /// </summary>
    internal class ReceiptStatementOperations : BasePartnerComponent<Tuple<string, string>>, IReceiptStatement
    {
        /// <summary>
        /// The accept media type for the a PDF file.
        /// </summary>
        private const string PdfAcceptMediaType = "application/pdf";

        /// <summary>
        /// Initializes a new instance of the <see cref="ReceiptStatementOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <param name="receiptId">The receipt identifier.</param>
        public ReceiptStatementOperations(IPartner rootPartnerOperations, string invoiceId, string receiptId)
            : base(rootPartnerOperations, new Tuple<string, string>(invoiceId, receiptId))
        {
            invoiceId.AssertNotEmpty(nameof(invoiceId));
            receiptId.AssertNotEmpty(nameof(receiptId));
        }

        /// <summary>
        /// Retrieves the receipt statement. This operation is currently only supported for user based credentials.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice statement.</returns>
        public async Task<Stream> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetFileContentAsync(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoiceTaxReceiptStatement.Path}",
                        Context),
                    UriKind.Relative),
                PdfAcceptMediaType,
                cancellationToken).ConfigureAwait(false);
        }
    }
}
