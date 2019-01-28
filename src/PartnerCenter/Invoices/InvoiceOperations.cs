// -----------------------------------------------------------------------
// <copyright file="InvoiceOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.Invoices;

    /// <summary>
    /// Operations available for the reseller's invoice.
    /// </summary>
    internal class InvoiceOperations : BasePartnerComponent<string>, IInvoice
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="invoiceId">The invoice id.</param>
        public InvoiceOperations(IPartner rootPartnerOperations, string invoiceId)
          : base(rootPartnerOperations, invoiceId)
        {
        }

        /// <summary>
        /// Gets an invoice documents operations.
        /// </summary>
        public IInvoiceDocuments Documents => new InvoiceDocumentsOperations(Partner, Context);

        /// <summary>
        /// Creates an invoice line item collection operation given a billing provider and invoice line item type.
        /// </summary>
        /// <param name="billingProvider">The billing provider.</param>
        /// <param name="invoiceLineItemType">The invoice line item type.</param>
        /// <returns>The invoice line item collection operations.</returns>
        public IInvoiceLineItemCollection By(BillingProvider billingProvider, InvoiceLineItemType invoiceLineItemType)
            => new InvoiceLineItemCollectionOperations(Partner, Context, billingProvider, invoiceLineItemType);

        /// <summary>
        /// Retrieves information about a specific invoice.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice.</returns>
        public Invoice Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves information about a specific invoice.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The invoice.</returns>
        public async Task<Invoice> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<Invoice>(
               new Uri(
                   string.Format(
                       CultureInfo.InvariantCulture,
                       $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoice.Path}",
                       Context),
                   UriKind.Relative),
               cancellationToken).ConfigureAwait(false);
        }
    }
}