// -----------------------------------------------------------------------
// <copyright file="IEntityGetOperationsIEntitySelector.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.GenericOperations
{
    /// <summary>
    /// Defines operations for selecting an entity out of a collection.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity behavior.</typeparam>
    public interface IEntitySelector<out TEntity>
    {
        /// <summary>
        /// Gets the behavior for an entity using the entity's identifer.
        /// </summary>
        /// <param name="id">The entity's ID.</param>
        /// <returns>The entity's behavior.</returns>
        TEntity this[string id] { get; }

        /// <summary>
        /// Retrieves the behavior for an entity using the entity's identifier.
        /// </summary>
        /// <param name="id">The entity's ID.</param>
        /// <returns>The entity's behavior.</returns>
        TEntity ById(string id);
    }
}