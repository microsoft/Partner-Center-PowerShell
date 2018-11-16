// -----------------------------------------------------------------------
// <copyright file="SeekBasedResourceCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    [JsonObject]
    public sealed class SeekBasedResourceCollection<TResource> : ResourceCollection<TResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeekBasedResourceCollection{TResource}" /> class.
        /// </summary>
        /// <param name="items">The collection whose elements are copied to the new list.</param>
        public SeekBasedResourceCollection(ICollection<TResource> items) : base(items)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeekBasedResourceCollection{TResource}" /> class.
        /// </summary>
        /// <param name="items">The collection whose elements are copied to the new list.</param>
        /// <param name="continuationToken">The continuation token used when performing HTTP operations.</param>
        [JsonConstructor]
        public SeekBasedResourceCollection(ICollection<TResource> items, string continuationToken) : this(items)
        {
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Gets or sets the continuation token.
        /// </summary>
        public string ContinuationToken { get; private set; }
    }
}