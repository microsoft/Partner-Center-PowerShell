// -----------------------------------------------------------------------
// <copyright file="ICategoryOffersCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.GenericOperations
{
    using Models;

    /// <summary>
    /// Groups all operations related to retrieving a collection of entities.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TResourceCollection">The entity collection type.</typeparam>
    public interface IEntityCollectionRetrievalOperations<T, TResourceCollection> : IEntireEntityCollectionRetrievalOperations<T, TResourceCollection>, IPagedEntityCollectionRetrievalOperations<T, TResourceCollection> where T : ResourceBase where TResourceCollection : ResourceCollection<T>
    {
    }
}