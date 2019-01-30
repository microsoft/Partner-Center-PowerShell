// -----------------------------------------------------------------------
// <copyright file="IEntityCreateOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Groups operations for creating a single entity.
    /// </summary>
    /// <typeparam name="T">The entity type request.</typeparam>
    /// <typeparam name="T1">The entity type response.</typeparam>
    public interface IEntityCreateOperations<in T, T1>
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <param name="newEntity">The new entity information.</param>
        /// <returns>The entity information that was just created.</returns>
        T1 Create(T newEntity, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="newEntity">The new entity information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entity information that was just created.</returns>
        Task<T1> CreateAsync(T newEntity, CancellationToken cancellationToken = default(CancellationToken));
    }
}