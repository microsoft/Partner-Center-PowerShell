// -----------------------------------------------------------------------
// <copyright file="ResourceBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models
{
    public abstract class ResourceBase
    {
        /// <summary>
        /// Intializes a new instance of the <see cref="ResourceBase" /> class.
        /// </summary>
        protected ResourceBase()
        {
            Attributes = new ResourceAttributes(GetType());
        }

        /// <summary>
        /// Initializes a enw instance of the <see cref="ResourceBase" /> class.
        /// </summary>
        /// <param name="objectType">The type of object.</param>
        protected ResourceBase(string objectType) : this()
        {
            Attributes.ObjectType = objectType;
        }

        /// <summary>
        /// Gets or sets the resource attributes.
        /// </summary>
        public ResourceAttributes Attributes { get; }
    }
}