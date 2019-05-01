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
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TResponse">The return type.</typeparam>
    public interface IEntityUpdateOperations<TEntity, TResponse>
    {
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity">The entity information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated entity.</returns>
        Task<TResponse> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}