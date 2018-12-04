// -----------------------------------------------------------------------
// <copyright file="IEntityDeleteOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;

    /// <summary>
    /// Groups operations for deleting a single entity.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    public interface IEntityDeleteOperations<T> where T : ResourceBase
    {
        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        void Delete(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}