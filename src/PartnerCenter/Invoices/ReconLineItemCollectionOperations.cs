// -----------------------------------------------------------------------
// <copyright file="ReconLineItemCollectionOperations.cs" company="Microsoft">
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
    using Extensions;
    using Models;
    using Models.Invoices;
    using Models.JsonConverters;

    /// <summary>
    /// The operations available for the partner's recon line item collection.
    /// </summary>
    internal class ReconLineItemCollectionOperations : BasePartnerComponent<string>, IReconLineItemCollection
    {
        /// <summary>
        /// The maximum page size for recon line items.
        /// </summary>
        private const int maxPageSizeReconLineItems = 2000;

        /// <summary>
        /// The type of billing provider for the unbilled recon line items.
        /// </summary>
        private readonly BillingProvider billingProvider;

        /// <summary>
        /// The currency code for the recon line itmes.
        /// </summary>
        private readonly string currencyCode;

        /// <summary>
        ///The type of invoice line items.
        /// </summary>
        private readonly InvoiceLineItemType invoiceLineItemType;

        /// <summary>
        /// The default page size for the unbilled recon line items.
        /// </summary>
        private readonly int pageSize;

        /// <summary>
        /// The period for the unbilled recon line items.
        /// </summary>
        private readonly BillingPeriod period;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReconLineItemCollectionOperations"/> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The partner operations.</param>
        /// <param name="invoiceId">The invoice Id.</param>
        /// <param name="billingProvider">The billing provider type.</param>
        /// <param name="invoiceLineItemType">The invoice line item type.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="period">The period for unbilled recon.</param>
        /// <param name="size">The page size.</param>
        public ReconLineItemCollectionOperations(IPartner rootPartnerOperations, string invoiceId, BillingProvider billingProvider, InvoiceLineItemType invoiceLineItemType, string currencyCode, BillingPeriod period, int? size = null)
            : base(rootPartnerOperations, invoiceId)
        {
            invoiceId.AssertNotEmpty(nameof(invoiceId));
            currencyCode.AssertNotEmpty(nameof(currencyCode));

            this.billingProvider = billingProvider;
            this.currencyCode = currencyCode;
            this.invoiceLineItemType = invoiceLineItemType;
            pageSize = size ?? maxPageSizeReconLineItems;
            this.period = period;
        }

        /// <summary>
        /// Gets the recon line items collection of the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of recon line items.</returns>
        public async Task<SeekBasedResourceCollection<InvoiceLineItem>> GetAsync(CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetReconLineItems.Parameters.CurrencyCode,
                    currencyCode
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetReconLineItems.Parameters.InvoiceLineItemType,
                    invoiceLineItemType.ToString()
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetReconLineItems.Parameters.Period,
                    period.ToString().ToLower(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetReconLineItems.Parameters.Provider,
                    billingProvider.ToString()
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetReconLineItems.Parameters.Size,
                    pageSize.ToString(CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<InvoiceLineItem>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetReconLineItems.Path}",
                        Context),
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<InvoiceLineItem>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}