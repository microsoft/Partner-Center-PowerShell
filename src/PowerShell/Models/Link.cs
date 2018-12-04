// -----------------------------------------------------------------------
// <copyright file="Link.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public sealed class Link
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Link" /> class.
        /// </summary>
        /// <param name="uri">The uniformed resource identifier (URI) for the link.</param>
        public Link(Uri uri)
          : this(uri, "GET", null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Link" /> class.
        /// </summary>
        /// <param name="uri">The uniformed resource identifier (URI) for the link.</param>
        /// <param name="method">The HTTP method used by the link.</param>
        /// <param name="headers">The headers associated with the link.</param>
        [JsonConstructor]
        public Link(Uri uri, string method, IEnumerable<KeyValuePair<string, string>> headers = null)
        {
            Uri = uri;
            Method = method;
            Headers = headers ?? new List<KeyValuePair<string, string>>();
        }

        /// <summary>
        /// Gets the uniformed resource identifier (URI) for this link.
        /// </summary>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the HTTP method used by this link.
        /// </summary>
        public string Method { get; private set; }

        /// <summary>
        /// Gets the headers associated with this link.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Headers { get; private set; }
    }
}