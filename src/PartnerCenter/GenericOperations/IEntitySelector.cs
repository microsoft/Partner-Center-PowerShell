// -----------------------------------------------------------------------
// <copyright file="IEntityGetOperationsIEntitySelector.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    /// <summary>
    /// Defines operations for selecting an entity out of a collection.
    /// </summary>
    /// <typeparam name="TTYpe">The type of identifier.</typeparam>
    /// <typeparam name="TEntity">The type of the entity behavior.</typeparam>
    public interface IEntitySelector<TTYpe, out TEntity>
    {
        /// <summary>
        /// Gets the behavior for an entity using the entity's identifer.
        /// </summary>
        /// <param name="id">The entity's identifier.</param>
        /// <returns>The entity's behavior.</returns>
        TEntity this[TTYpe id] { get; }

        /// <summary>
        /// Retrieves the behavior for an entity using the entity's identifier.
        /// </summary>
        /// <param name="id">The entity's identifier.</param>
        /// <returns>The entity's behavior.</returns>
        TEntity ById(TTYpe id);
    }
}