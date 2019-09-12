// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Rest;

    public class HttpMessageInfo
    {
        public HttpMessageInfo(HttpMessageWrapper message)
        {
            if (message != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> header in message.Headers)
                {
                    Headers[header.Key] = header.Value;
                }

                Body = message.Content;
            }
        }

        public string Body { get; }

        public IDictionary<string, IEnumerable<string>> Headers { get; } = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

    }
}