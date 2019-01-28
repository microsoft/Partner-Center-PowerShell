// -----------------------------------------------------------------------
// <copyright file="IResourceCollectionEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using RequestContext;

    /// <summary>
    /// Provides resource collection enumeration capabilities. This interface can page through results and determines whether the current page
    /// is the first or last page or not.
    /// </summary>
    /// <typeparam name="T">The enumeration result type.</typeparam>
    public interface IResourceCollectionEnumerator<T> where T : ResourceBaseWithLinks<StandardResourceCollectionLinks>
    {
        /// <summary>
        /// Gets whether the current result collection is the first page of results or not.
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Gets whether the current result collection is the last page of results or not.
        /// </summary>
        bool IsLastPage { get; }

        /// <summary>
        /// Gets whether the current result collection has a value or not. This indicates if the collection has been fully enumerated or not.
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Gets the current resource collection.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Retrieves the next result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        void Next(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Retrieves the next result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task which completes when fetching the next set of results is done.</returns>
        Task NextAsync(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the previous result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        void Previous(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves the previous result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task which completes when fetching the previous set of results is done.</returns>
        Task PreviousAsync(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}