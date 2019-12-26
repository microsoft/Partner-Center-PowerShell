// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System.Globalization;
    using Microsoft.Rest;

    /// <summary>
    /// Provides information regarding the HTTP response used during the resolution of errors.
    /// </summary>
    public class HttpResponseInfo : HttpMessageInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseInfo" /> class.
        /// </summary>
        /// <param name="response">The wrapper for the HTTP response.</param>
        public HttpResponseInfo(HttpResponseMessageWrapper response) : base(response)
        {
            response.AssertNotNull(nameof(response));

            ResponseStatusCode = response.StatusCode.ToString();
        }

        /// <summary>
        /// Gets or sets the response status code.
        /// </summary>
        public string ResponseStatusCode { get; set; }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{{{0}}}", ResponseStatusCode);
        }
    }
}
