// -----------------------------------------------------------------------
// <copyright file="IPagedEntityCollectionRetrievalOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Represents paged entity retrieval operations.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TResourceCollection">The entity collection type.</typeparam>
    public interface IPagedEntityCollectionRetrievalOperations<T, TResourceCollection> where T : ResourceBase where TResourceCollection : ResourceCollection<T>
    {
        /// <summary>Retrieves a subset of entities.</summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of entities to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested entities subset.</returns>
        TResourceCollection Get(int offset, int size, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>Asynchronously retrieves a subset of entities.</summary>
        /// <param name="offset">The starting index.</param>
        /// <param name="size">The maximum number of entities to return.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested entities subset.</returns>
        Task<TResourceCollection> GetAsync(int offset, int size, CancellationToken cancellationToken = default(CancellationToken));
    }
}