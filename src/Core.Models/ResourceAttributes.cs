// -----------------------------------------------------------------------
// <copyright file="ResourceAttributes.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models
{
    using System;
    using Newtonsoft.Json;

    public sealed class ResourceAttributes
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAttributes" /> class.
        /// </summary>
        public ResourceAttributes()
        {
        }

        /// <summary>
        /// Intializes a new instance of the <see cref="ResourceAttributes" /> class.
        /// </summary>
        /// <param name="type">The type of resource.</param>
        public ResourceAttributes(Type type)
        {
            if (type == null)
            {
                return;
            }

            ObjectType = type.Name;
        }

        /// <summary>
        /// Gets or sets the etag.
        /// </summary>
        [JsonProperty]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the object type.
        /// </summary>
        public string ObjectType { get; set; }
    }
}