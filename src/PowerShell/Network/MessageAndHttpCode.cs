// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents the message and status code used to respond to HTTP requests.
    /// </summary>
    internal class MessageAndHttpCode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageAndHttpCode" /> class.
        /// </summary>
        /// <param name="httpCode">The status code for the HTTP operation.</param>
        /// <param name="message">The message that will be sent with the response.</param>
        public MessageAndHttpCode(HttpStatusCode httpCode, string message)
        {
            HttpCode = httpCode;
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Gets the status code for the HTTP operation.
        /// </summary>
        public HttpStatusCode HttpCode { get; }

        /// <summary>
        /// Gets the message that will be sent with the response.
        /// </summary>
        public string Message { get; }
    }
}