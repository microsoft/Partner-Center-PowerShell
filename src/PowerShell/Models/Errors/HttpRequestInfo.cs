// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System;
    using Microsoft.Rest;

    public class HttpRequestInfo : HttpMessageInfo
    {
        public HttpRequestInfo(HttpRequestMessageWrapper request) : base(request)
        {
            Uri = request.RequestUri;
            Verb = request.Method.ToString();
        }

        public Uri Uri { get; }

        public string Verb { get; }

        public override string ToString()
        {
            return string.Format("{{{0} {1}}}", Verb, Uri);
        }
    }
}
