// -----------------------------------------------------------------------
// <copyright file="IInvoiceCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System.Threading;
    using System.Threading.Tasks;
    using GenericOperations;
    using Models;
    using Models.Invoices;
    using Models.Query;

    /// <summary>
    /// Represents the operations that can be done on the partner's invoices.
    /// </summary>
    public interface IInvoiceCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<Invoice, ResourceCollection<Invoice>>, IEntitySelector<IInvoice>
    {
        /// <summary>
        /// Gets an invoice summary operations.
        /// </summary>
        /// <returns>The invoice summary operations.</returns>
        IInvoiceSummary Summary { get; }

        /// <summary>
        /// Gets invoice summary collection operations.
        /// </summary>
        /// <returns>The invoice summary collection.</returns>
        IInvoiceSummaryCollection Summaries { get; }

        /// <summary>
        /// Queries invoices associated to the partner.
        /// </summary>
        /// <param name="query">The invoice query.
        /// The <see cref="QueryFactory" /> can be used to build queries.
        /// Invoice queries support simple and indexed queries. You can retrieve subsets of invoices by providing an indexed query and specifying the index to start from
        /// and the page size to retrieve.
        /// You can also filter invoices using their dates. <see cref="InvoiceSearchField" /> lists
        /// the supported search fields. You can use the <see cref="FieldFilterOperation" /> enumeration to specify filtering operations.
        /// Supported filtering operations are: greater than, greater than or equals, less than, less than or equals, equals, and not equals. You can also compose compound filters
        /// that use the AND and OR field filter operations to retrieve a specific invoice subset.
        /// </param>
        /// <returns>The invoices that match the given query.</returns>
        Task<ResourceCollection<Invoice>> QueryAsync(IQuery query, CancellationToken cancellationToken = default);
    }
}