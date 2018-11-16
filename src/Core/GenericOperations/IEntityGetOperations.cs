// -----------------------------------------------------------------------
// <copyright file="IEntityGetOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Groups operations for getting a single entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IEntityGetOperations<T>
    {
        /// <summary>
        /// Retrieves an entity.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entity.</returns>
        T Get(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves an entity.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The entity.</returns>
        Task<T> GetAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}