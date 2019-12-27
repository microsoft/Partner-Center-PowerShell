// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Net;

    internal class MessageAndHttpCode
    {
        public MessageAndHttpCode(HttpStatusCode httpCode, string message)
        {
            HttpCode = httpCode;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public HttpStatusCode HttpCode { get; }

        public string Message { get; }
    }
}