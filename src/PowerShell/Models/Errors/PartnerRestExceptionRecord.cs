// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Errors
{
    using System.Management.Automation;
    using PartnerCenter.Exceptions;

    public class PartnerRestExceptionRecord : PartnerExceptionRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerRestExceptionRecord" /> class.
        /// </summary>
        /// <param name="exception">The error that occur during command execution.</param>
        /// <param name="record">The record of the error.</param>
        public PartnerRestExceptionRecord(PartnerException exception, ErrorRecord record) :
            base(exception, record)
        {
            if (exception != null)
            {
                //if (exception.Body != null)
                //{
                //    ServerMessage = string.Format($"{exception.Body.Code}: {exception.Body.Message} ({exception.Body.Details})");
                //}

                if (exception.Response != null)
                {
                    ServerResponse = new HttpResponseInfo(exception.Response);
                }

                if (exception.Request != null)
                {
                    RequestMessage = new HttpRequestInfo(exception.Request);
                }

                CorrelationId = exception.Context.CorrelationId.ToString();
                Locale = exception.Context.Locale;
                RequestId = exception.Context.RequestId.ToString();
            }
        }

        /// <summary>
        /// Gets the correlation identifier for the request.
        /// </summary>
        public string CorrelationId { get; }

        /// <summary>
        /// Gets the locale for the request.
        /// </summary>
        public string Locale { get; }

        /// <summary>
        /// Gets the identifier for the request.
        /// </summary>
        public string RequestId { get; }

        /// <summary>
        /// Gets the request message.
        /// </summary>
        public HttpRequestInfo RequestMessage { get; }

        /// <summary>
        /// Gets the message returned from the server.
        /// </summary>
        public string ServerMessage { get; }

        /// <summary>
        /// Gets the response from the server.
        /// </summary>
        public HttpResponseInfo ServerResponse { get; }
    }
}
