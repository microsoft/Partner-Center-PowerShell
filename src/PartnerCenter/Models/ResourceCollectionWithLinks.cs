// -----------------------------------------------------------------------
// <copyright file="ResourceCollectionWithLinks.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public class ResourceCollection<TResource, TLinks> : ResourceBaseWithLinks<TLinks> where TLinks : new()
    {
        private readonly ICollection<TResource> internalItems;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCollection{TResource, TLinks}" /> class.
        /// </summary>
        /// <param name="items">The collection whose elements are copied to the new list.</param>
        public ResourceCollection(ICollection<TResource> items)
          : base("Collection")
        {
            internalItems = items ?? new List<TResource>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceCollection{TResource, TLinks}" /> class.
        /// </summary>
        /// <param name="resourceCollection">The resource collection whose elements are copied to the new list.</param>
        protected ResourceCollection(ResourceCollection<TResource, TLinks> resourceCollection)
          : base("Collection")
        {
            if (resourceCollection == null)
            {
                throw new ArgumentNullException(nameof(resourceCollection));
            }

            internalItems = resourceCollection.internalItems;
        }

        /// <summary>
        /// Gets the items of the resource collection.
        /// </summary>
        public IEnumerable<TResource> Items => internalItems;

        /// <summary>
        /// Gets the total count of the elements in the resource collection.
        /// </summary>
        [JsonProperty]
        public int TotalCount => internalItems.Count;
    }
}
