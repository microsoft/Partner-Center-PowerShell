// -----------------------------------------------------------------------
// <copyright file="IEntityUpdateOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Groups operations for updating a single entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="V">The return type.</typeparam>
    public interface IEntityUpdateOperations<T, V>
    {
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated entity.</returns>
        Task<V> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    }
}