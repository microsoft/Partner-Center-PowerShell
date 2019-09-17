// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Text.RegularExpressions;
    using Extensions;

    /// <summary>
    /// Represents the response of a HTTP operation.
    /// </summary>
    public sealed class HttpResponseRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseRecord" /> class.
        /// </summary>
        public HttpResponseRecord()
        {
            RequestHeaders = new Dictionary<string, List<string>>();
            ResponseHeaders = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseRecord" /> class.
        /// </summary>
        /// <param name="response">The response from the HTTP operation.</param>
        public HttpResponseRecord(HttpResponseMessage response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            EncodedReqeustAddress = Convert.ToBase64String(Encoding.UTF8.GetBytes(response.RequestMessage.RequestUri.PathAndQuery));
            RequestHeaders = new Dictionary<string, List<string>>();
            RequestMethod = response.RequestMessage.Method.ToString();
            RequestUri = response.RequestMessage.RequestUri;
            ResponseHeaders = new Dictionary<string, List<string>>();
            StatusCode = response.StatusCode;

            response.RequestMessage.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            response.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));

            if (DetectContentType(response.Content) != HttpContentType.Null)
            {
                ResponseBody = HttpUtilities.FormatHttpContent(response.Content);
                ResponseBody = Regex.Replace(ResponseBody, @"(?<=continuation_token\=)(.*)(?=%3d%3d)", string.Empty);
                response.Content.Headers.ForEach(h => ResponseHeaders.Add(h.Key, h.Value.ToList()));
            }

            if (DetectContentType(response.RequestMessage.Content) != HttpContentType.Null)
            {
                RequestBody = HttpUtilities.FormatHttpContent(response.RequestMessage.Content);
                response.RequestMessage.Content.Headers.ForEach(h => RequestHeaders.Add(h.Key, h.Value.ToList()));
            }
        }

        /// <summary>
        /// Gets or sets the request addressed encoded as a base64 string.
        /// </summary>
        public string EncodedReqeustAddress { get; set; }

        /// <summary>
        /// Gets or sets the body of the HTTP request.
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// Gets or sets the HTTP headers for the HTTP request.
        /// </summary>
        public Dictionary<string, List<string>> RequestHeaders { get; }

        /// <summary>
        /// Gets or sets the request HTTP method.
        /// </summary>
        public string RequestMethod { get; set; }

        /// <summary>
        /// Gets or sets the URI used for the HTTP request.
        /// </summary>
        public Uri RequestUri { get; set; }

        /// <summary>
        /// Gets or sets the body of the HTTP response.
        /// </summary>
        public string ResponseBody { get; set; }

        /// <summary>
        /// Gets or sets the HTTP headers for the HTTP response.
        /// </summary>
        public Dictionary<string, List<string>> ResponseHeaders { get; }

        /// <summary>
        /// Gets or sets the status code of the HTTP response.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets an instance the <see cref="HttpResponseMessage" /> class that represents this HTTP operation.
        /// </summary>
        /// <returns>
        /// An instance of the <see cref="HttpResponseMessage" /> class that represents the HTTP operation.
        /// </returns>
        public HttpResponseMessage GetResponse()
        {
            HttpResponseMessage response = new HttpResponseMessage()
            {
                Content = HttpUtilities.CreateHttpContent(ResponseBody),
                StatusCode = StatusCode
            };

            ResponseHeaders.ForEach(h => response.Content.Headers.TryAddWithoutValidation(h.Key, h.Value));
            ResponseHeaders.ForEach(h => response.Headers.TryAddWithoutValidation(h.Key, h.Value));

            return response;
        }

        private static HttpContentType DetectContentType(HttpContent content)
        {
            HttpContentType contentType = HttpContentType.Null;

            if (content != null)
            {
                if (HttpUtilities.IsHttpContentBinary(content))
                {
                    contentType = HttpContentType.Binary;
                }
                else
                {
                    contentType = HttpContentType.Ascii;
                }
            }

            return contentType;
        }
    }
}