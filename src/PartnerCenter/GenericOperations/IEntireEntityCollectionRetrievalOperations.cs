// -----------------------------------------------------------------------
// <copyright file="IEntireEntityCollectionRetrievalOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// A generic interface which represents operations for getting an entire collection of entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TResourceCollection">The entity collection type.</typeparam>
    public interface IEntireEntityCollectionRetrievalOperations<T, TResourceCollection> where TResourceCollection : ResourceCollection<T>
    {
        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entities.</returns>
        Task<TResourceCollection> GetAsync(CancellationToken cancellationToken = default);
    }
}