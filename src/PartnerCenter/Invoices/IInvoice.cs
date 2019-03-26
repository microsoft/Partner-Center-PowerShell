// -----------------------------------------------------------------------
// <copyright file="IInvoice.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models.Invoices;

    /// <summary>
    /// Represents all the operations that can be done on an invoice.
    /// </summary>
    public interface IInvoice : IPartnerComponent<string>, IEntityGetOperations<Invoice>
    {
        /// <summary>
        /// Gets the invoice's documents operations.
        /// </summary>
        IInvoiceDocuments Documents { get; }

        /// <summary>
        /// Gets the receipts behavior of the invoice.
        /// </summary>
        IReceiptCollection Receipts { get; }

        /// <summary>
        /// Creates an invoice line item collection operations given a billing provider and invoice line item type.
        /// </summary>
        /// <param name="billingProvider">The billing provider.</param>
        /// <param name="invoiceLineItemType">The invoice line item type.</param>
        /// <returns>The invoice line item collection operations.</returns>
        IInvoiceLineItemCollection By(BillingProvider billingProvider, InvoiceLineItemType invoiceLineItemType);

        /// <summary>
        /// Creates an invoice line item collection operations given a billing provider and invoice line item type.
        /// </summary>
        /// <param name="provider">The provider type.</param>
        /// <param name="invoiceLineItemType">The invoice line item.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="period">The period for unbilled recon.</param>
        /// <param name="size">The page size.</param>
        /// <returns>The recon line item collection operations.</returns>
        IReconciliationLineItemCollection By(BillingProvider provider, InvoiceLineItemType invoiceLineItemType, string currencyCode, BillingPeriod period, int? size = null);
    }
}