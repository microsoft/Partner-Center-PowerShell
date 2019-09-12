// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using Microsoft.Rest;

    public class HttpResponseInfo : HttpMessageInfo
    {
        public HttpResponseInfo(HttpResponseMessageWrapper response) : base(response)
        {
            ResponseStatusCode = response.StatusCode.ToString();
        }

        public string ResponseStatusCode { get; set; }

        public override string ToString()
        {
            return string.Format("{{{0}}}", ResponseStatusCode);
        }
    }
}
