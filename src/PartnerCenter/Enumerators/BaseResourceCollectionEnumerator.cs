// -----------------------------------------------------------------------
// <copyright file="BaseResourceCollectionEnumerator.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Enumerators
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;
    using RequestContext;

    /// <summary>
    /// Base implementation for resource collection enumerators.
    /// </summary>
    /// <typeparam name="T">The type of the resource collection.</typeparam>
    internal abstract class BaseResourceCollectionEnumerator<T> : BasePartnerComponent<string>, IResourceCollectionEnumerator<T> where T : ResourceBaseWithLinks<StandardResourceCollectionLinks>
    {
        /// <summary>
        /// The current resource collection.
        /// </summary>
        private T resourceCollection;

        /// <summary>
        /// The resource collection JSON converter.
        /// </summary>
        private readonly JsonConverter resourceCollectionConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResourceCollectionEnumerator{T}" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="resourceCollection">The initial resource collection.</param>
        /// <param name="resourceCollectionConverter">An optional converter.</param>
        protected BaseResourceCollectionEnumerator(IPartner rootPartnerOperations, T resourceCollection, JsonConverter resourceCollectionConverter = null)
          : base(rootPartnerOperations, null)
        {
            this.resourceCollection = resourceCollection ?? throw new ArgumentNullException(nameof(resourceCollection));
            this.resourceCollectionConverter = resourceCollectionConverter;
        }

        /// <summary>
        /// Gets whether the current customer collection is the first page of results or not.
        /// </summary>
        public bool IsFirstPage
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("The enumerator does not have a current value");
                }

                if (Current.Links != null)
                {
                    return Current.Links.Previous == null;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets whether the current customer collection is the last page of results or not.
        /// </summary>
        public bool IsLastPage
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("The enumerator does not have a current value");
                }

                if (Current.Links != null)
                {
                    return Current.Links.Next == null;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets whether the current result collection has a value or not. This indicates if the collection has been fully enumerated or not.
        /// </summary>
        public bool HasValue => resourceCollection != null;

        /// <summary>
        /// Gets the current resource collection.
        /// </summary>
        public T Current => resourceCollection;

        /// <summary>
        /// Retrieves the next customer result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public void Next(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            PartnerService.SynchronousExecute(() => NextAsync(context, cancellationToken));
        }

        /// <summary>
        /// Retrieves the next customer result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task which completes when fetching the next set of results is done.</returns>
        public async Task NextAsync(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!HasValue)
            {
                throw new InvalidOperationException("The enumerator does not have a current value");
            }

            if (IsLastPage)
            {
                resourceCollection = default(T);
            }
            else
            {
                resourceCollection =
                    await Partner.ServiceClient.GetAsync<T>(
                        resourceCollection.Links.Next,
                        resourceCollectionConverter,
                        cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Retrieves the previous customer result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public void Previous(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            PartnerService.SynchronousExecute(() => PreviousAsync(context, cancellationToken));
        }

        /// <summary>
        /// Retrieves the previous customer result set.
        /// </summary>
        /// <param name="context">An optional request context. If not provided, the context associated with the partner operations will be used.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task which completes when fetching the previous set of results is done.</returns>
        public async Task PreviousAsync(IRequestContext context = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!HasValue)
            {
                throw new InvalidOperationException("The enumerator does not have a current value");
            }

            if (IsFirstPage)
            {
                resourceCollection = default(T);
            }
            else
            {
                resourceCollection = await Partner.ServiceClient.GetAsync<T>(
                    resourceCollection.Links.Previous,
                    resourceCollectionConverter,
                    cancellationToken).ConfigureAwait(false);
            }
        }
    }
}