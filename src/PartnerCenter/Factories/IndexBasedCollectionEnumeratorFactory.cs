// -----------------------------------------------------------------------
// <copyright file="IndexBasedCollectionEnumeratorFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Factories
{
    using Enumerators;
    using Models;
    using Models.Invoices;
    using Models.JsonConverters;

    /// <summary>
    /// Factory method for creating a new instance of index based collection enumerator.
    /// </summary>
    /// <typeparam name="T">The type of resource.</typeparam>
    /// <typeparam name="TResourceCollection">The type of resource collection.</typeparam>
    internal class IndexBasedCollectionEnumeratorFactory<T, TResourceCollection> : BasePartnerComponent<string>, IResourceCollectionEnumeratorFactory<TResourceCollection> where T : ResourceBase where TResourceCollection : ResourceCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexBasedCollectionEnumeratorFactory{T, TResourceCollection}" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public IndexBasedCollectionEnumeratorFactory(IPartner rootPartnerOperations)
          : base(rootPartnerOperations, null)
        {
        }

        /// <summary>
        /// Creates a index based collection enumerator capable of traversing resources that uses offset and page size for pagination.
        /// </summary>
        /// <param name="resourceCollection">The initial resource collection to start from.</param>
        /// <returns>A resource collection enumerator capable of traversing the resource objects within the collection.</returns>
        public IResourceCollectionEnumerator<TResourceCollection> Create(TResourceCollection resourceCollection)
        {
            return new IndexBasedCollectionEnumerator<T, TResourceCollection>(
                Partner,
                resourceCollection,
                new ResourceCollectionConverter<Invoice>());
        }
    }
}