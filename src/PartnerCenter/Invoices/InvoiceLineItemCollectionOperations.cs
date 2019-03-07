// -----------------------------------------------------------------------
// <copyright file="InvoiceLineItemCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Invoices;

    /// <summary>
    /// The operations available for the partner's invoice line item collection.
    /// </summary>
    internal class InvoiceLineItemCollectionOperations : BasePartnerComponent<string>, IInvoiceLineItemCollection
    {
        /// <summary>
        /// The provider of billing information.
        /// </summary>
        private readonly BillingProvider billingProvider;

        /// <summary>
        /// The type of invoice line item.
        /// </summary>
        private readonly InvoiceLineItemType invoiceLineItemType;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceLineItemCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The partner operations.</param>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <param name="billingProvider">The provider of billing information,</param>
        /// <param name="invoiceLineItemType">The type of invoice line item.</param>
        public InvoiceLineItemCollectionOperations(IPartner rootPartnerOperations, string invoiceId, BillingProvider billingProvider, InvoiceLineItemType invoiceLineItemType)
          : base(rootPartnerOperations, invoiceId)
        {
            this.billingProvider = billingProvider;
            this.invoiceLineItemType = invoiceLineItemType;
        }

        /// <summary>
        ///  Retrieves invoice line items for a specific billing provider and invoice line item type
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of invoice line items.</returns>
        public async Task<ResourceCollection<InvoiceLineItem>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<InvoiceLineItem>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoiceLineItems.Path}",
                        Context,
                        billingProvider,
                        invoiceLineItemType),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///  Retrieves a subset of invoice line items for a specific billing provider and invoice line item type
        /// </summary>
        /// <param name="size">The maximum number of invoice line items to return.</param>
        /// <param name="offset">The page offset.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subset of invoice line items.</returns>
        public async Task<ResourceCollection<InvoiceLineItem>> GetAsync(int offset, int size, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetInvoiceLineItems.Parameters.Offset,
                    offset.ToString(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetInvoiceLineItems.Parameters.Size,
                    size.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<InvoiceLineItem>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoiceLineItems.Path}",
                        Context,
                        billingProvider,
                        invoiceLineItemType),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}