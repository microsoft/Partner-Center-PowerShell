// -----------------------------------------------------------------------
// <copyright file="InvoiceCollectionOperations.cs" company="Microsoft">
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
    using Models.Query;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the operations that can be done on Partner's invoices.
    /// </summary>
    internal class InvoiceCollectionOperations : BasePartnerComponent<string>, IInvoiceCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public InvoiceCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets a single invoice operations.
        /// </summary>
        /// <param name="invoiceId">The invoice identifier.</param>
        /// <returns>The invoice operations.</returns>
        public IInvoice this[string invoiceId] => ById(invoiceId);

        /// <summary>
        /// Gets a single invoice summary operations.
        /// </summary>
        public IInvoiceSummary Summary => new InvoiceSummaryOperations(Partner);

        /// <summary>
        /// Gets invoice summaries operations.
        /// </summary>
        public IInvoiceSummaryCollection Summaries => new InvoiceSummaryCollectionOperations(Partner);

        /// <summary>
        /// Gets a single invoice operations.
        /// </summary>
        /// <param name="id">The invoice identifier.</param>
        /// <returns>The invoice operations.</returns>
        public IInvoice ById(string id)
        {
            return new InvoiceOperations(Partner, id);
        }

        /// <summary>
        /// Retrieves all invoices associated to the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of invoices.</returns>
        public ResourceCollection<Invoice> Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Retrieves all invoices associated to the partner.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The collection of invoices.</returns>
        public async Task<ResourceCollection<Invoice>> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ResourceCollection<Invoice>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoices.Path}",
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all invoices associated to the partner.
        /// </summary>
        /// <param name="query">The query parameter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subset of invoices.</returns>
        public ResourceCollection<Invoice> Query(IQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => QueryAsync(query, cancellationToken));
        }

        /// <summary>
        /// Retrieves all invoices associated to the partner.
        /// </summary>
        /// <param name="query">The query parameter.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The subset of invoices.</returns>
        public async Task<ResourceCollection<Invoice>> QueryAsync(IQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            query.AssertNotNull(nameof(query));

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (query.Type == QueryType.Indexed)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetInvoices.Parameters.Offset,
                    query.Index.ToString(CultureInfo.InvariantCulture));

                parameters.Add(
                     PartnerService.Instance.Configuration.Apis.GetInvoices.Parameters.Size,
                     query.PageSize.ToString(CultureInfo.InvariantCulture));
            }

            if (query.Filter != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetInvoices.Parameters.Filter,
                    JsonConvert.SerializeObject(query.Filter));
            }

            return await Partner.ServiceClient.GetAsync<ResourceCollection<Invoice>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetInvoices.Path}",
                    UriKind.Relative),
                parameters,
                new ResourceCollectionConverter<Invoice>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}