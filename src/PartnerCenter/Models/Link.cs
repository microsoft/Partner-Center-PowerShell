// -----------------------------------------------------------------------
// <copyright file="Link.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a URI and the HTTP method which indicates the desired action for accessing the resource.
    /// </summary>
    public sealed class Link
    {
        /// <summary>
        /// Gets the headers associated with this link.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers { get; private set; }
        
        /// <summary>
        /// Gets the HTTP method used by this link.
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// Gets the uniformed resource identifier (URI) for this link.
        /// </summary>
        public Uri Uri { get; private set; }
    }
}