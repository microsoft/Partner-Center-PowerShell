// -----------------------------------------------------------------------
// <copyright file="IEntityExistsOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Groups operations for checking if a single entity exists or not.
    /// </summary>
    public interface IEntityExistsOperations
    {

        /// <summary>
        /// Checks if an entity exists or not.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// <c>true</c> if the entity exists; otherwise <c>false</c>.
        /// </returns>
        Task<bool> ExistsAsync(CancellationToken cancellationToken = default);
    }
}