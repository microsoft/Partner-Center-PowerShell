// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using Extensions;

    /// <summary>
    /// Used by the mock server for mapping a request with it's corresponding response.
    /// </summary>
    public class HttpRecordMatcher : IHttpRecordMatcher
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRecordMatcher" /> class.
        /// </summary>
        /// <param name="matchingHeaders">The headers used to match the record.</param>
        public HttpRecordMatcher(params string[] matchingHeaders)
        {
            MatchingHeaders = new HashSet<string>(matchingHeaders, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gets the matching headers.
        /// </summary>
        public HashSet<string> MatchingHeaders { get; }

        /// <summary>
        /// Gets the key used for mapping a given record request's with its response.
        /// </summary>
        /// <param name="record">The record entry containing the request info</param>
        /// <returns>The key used for the mapping.</returns>
        public string GetMatchingKey(HttpResponseRecord record)
        {
            return GetMatchingKey(record.RequestMethod,
                (record.EncodedReqeustAddress ?? Convert.ToBase64String(Encoding.UTF8.GetBytes(record.RequestUri.PathAndQuery))),
                record.RequestHeaders);
        }

        /// <summary>
        /// Gets the key mapping for the given request.
        /// </summary>
        /// <param name="request">The request to be mapped.</param>
        /// <returns>The key corresponding to this request.</returns>
        public string GetMatchingKey(HttpRequestMessage request)
        {
            Dictionary<string, List<string>> requestHeaders = new Dictionary<string, List<string>>();

            request.Headers.ForEach(h => requestHeaders.Add(h.Key, h.Value.ToList()));

            if (request.Content != null)
            {
                request.Content.Headers.ForEach(h => requestHeaders.Add(h.Key, h.Value.ToList()));
            }

            return GetMatchingKey(
                request.Method.Method,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(request.RequestUri.PathAndQuery)),
                requestHeaders);
        }

        private string GetMatchingKey(string httpMethod, string requestUri, Dictionary<string, List<string>> requestHeaders)
        {
            StringBuilder key = new StringBuilder($"{httpMethod} {requestUri}");

            if (requestHeaders != null)
            {
                foreach (KeyValuePair<string, List<string>> requestHeader in requestHeaders.OrderBy(h => h.Key))
                {
                    if (MatchingHeaders.Contains(requestHeader.Key))
                    {
                        key.AppendFormat(
                            CultureInfo.InvariantCulture,
                            " ({0}={1})",
                            requestHeader.Key,
                            string.Join(",", requestHeader.Value));
                    }
                }
            }

            return key.ToString();
        }
    }
}