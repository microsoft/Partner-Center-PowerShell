// -----------------------------------------------------------------------
// <copyright file="IndexBasedCollectionEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumerator for index based pagination
    /// Index based - Paged query where index and page size is used.
    /// </summary>
    /// <typeparam name="T">The type of resource</typeparam>
    /// <typeparam name="TResourceCollection">The type of resource collection.</typeparam>
    internal class IndexBasedCollectionEnumerator<T, TResourceCollection> : BaseResourceCollectionEnumerator<TResourceCollection> where T : ResourceBase where TResourceCollection : ResourceCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexBasedCollectionEnumerator{T, TResourceCollection}"/> class.
        /// </summary>
        /// <param name="partnerOperations">A partner operations instance.</param>
        /// <param name="seekBasedResourceCollection">The paged resource collection to enumerate from.</param>
        /// <param name="resourceCollectionConverter">Optional: The resource collection converter.</param>
        public IndexBasedCollectionEnumerator(IPartner partnerOperations, TResourceCollection seekBasedResourceCollection, JsonConverter resourceCollectionConverter = null)
          : base(partnerOperations, seekBasedResourceCollection, resourceCollectionConverter)
        {
        }
    }
}