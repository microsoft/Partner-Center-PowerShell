// -----------------------------------------------------------------------
// <copyright file="ResourceCollectionEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Enumerators
{
    using System.Threading.Tasks;
    using Common;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using RequestContext;

    /// <summary>
    /// Provides resource collection enumeration capabilities.
    /// </summary>
    /// <typeparam name="T">The enumeration result type.</typeparam>
    public sealed class ResourceCollectionEnumerator<T> : IResourceCollectionEnumerator<T> where T : ResourceBaseWithLinks<StandardResourceCollectionLinks>
    {
        /// <summary>
        /// The current resource collection.
        /// </summary>
        private T resourceCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCollectionEnumerator{T}" /> class.
        /// </summary>
        /// <param name="resourceCollection">The initial resource collection.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="resourceCollection" /> is null.
        /// </exception>
        public ResourceCollectionEnumerator(T resourceCollection)
        {
            resourceCollection.AssertNotNull(nameof(resourceCollection));

            this.resourceCollection = resourceCollection;
        }

        /// <summary>
        /// Gets the current resource collection.
        /// </summary>
        public T Current => resourceCollection;

        /// <summary>
        /// Gets whether the current result collection has a value or not. This indicates if the collection has been fully enumerated or not.
        /// </summary>
        public bool HasValue => resourceCollection != null; 

        /// <summary>
        /// Gets whether the current result collection is the first page of results or not.
        /// </summary>
        public bool IsFirstPage => true;

        /// <summary>
        /// Gets whether the current result collection is the first page of results or not.
        /// </summary>
        public bool IsLastPage => true;

        /// <summary>
        /// Retrieves the next result set.
        /// </summary>
        /// <param name="context">
        /// An optional request context. If not provided, the context associated with the partner operations will be used.
        /// </param>
        public void Next(IRequestContext context = null)
        {
            resourceCollection = default(T);
        }

        /// <summary>
        /// Retrieves the next result set.
        /// </summary>
        /// <param name="context">
        /// An optional request context. If not provided, the context associated with the partner operations will be used.
        /// </param>
        public async Task NextAsync(IRequestContext context = null)
        {
            resourceCollection = default(T);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Retrieves the previous result set.
        /// </summary>
        /// <param name="context">
        /// An optional request context. If not provided, the context associated with the partner operations will be used.
        /// </param>
        public void Previous(IRequestContext context = null)
        {
            resourceCollection = default(T);
        }

        /// <summary>
        /// Retrieves the previous result set.
        /// </summary>
        /// <param name="context">
        /// An optional request context. If not provided, the context associated with the partner operations will be used.
        /// </param>
        public async Task PreviousAsync(IRequestContext context = null)
        {
            resourceCollection = default(T);

            await Task.CompletedTask; 
        }
    }
}