// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Rest;

    /// <summary>
    /// Delegating handler that provides tracing the request and response.
    /// </summary>
    public sealed class ClientTracingHandler : DelegatingHandler
    {
        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the execution of the operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            string invocationId = null;

            if (ServiceClientTracing.IsEnabled)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();

                NameValueCollection queryParameters = HttpUtility.ParseQueryString(request.RequestUri.Query);
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();

                foreach (string key in queryParameters.AllKeys)
                {
                    tracingParameters.Add(key, queryParameters[key]);
                }

                ServiceClientTracing.Enter(invocationId, this, "Send", tracingParameters);
                ServiceClientTracing.SendRequest(invocationId, request);
            }

            cancellationToken.ThrowIfCancellationRequested();
            response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            if (ServiceClientTracing.IsEnabled)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, response);
                //ServiceClientTracing.Exit(invocationId, null);
            }

            return response;
        }
    }
}