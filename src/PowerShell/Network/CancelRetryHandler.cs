// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Delegating handler that retries any operation that was aborted due to the <see cref="TaskCanceledException" /> being thrown.
    /// </summary>
    public class CancelRetryHandler : DelegatingHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CancelRetryHandler" /> class.
        /// </summary>
        /// <param name="maxTries">The maximum number of times the operation should be retried.</param>
        /// <param name="waitInterval">The interval to wait between retries.</param>
        public CancelRetryHandler(int maxTries, TimeSpan waitInterval)
        {
            MaxTries = maxTries;
            WaitInterval = waitInterval;
        }

        /// <summary>
        /// Gets or sets the maximum number of times the operation should be retried.
        /// </summary>
        public int MaxTries { get; set; } = 3;

        /// <summary>
        /// Gets or sets the interval to wait between retries.
        /// </summary>
        public TimeSpan WaitInterval { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the execution of the operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            int tries = 0;

            do
            {
                using (CancellationTokenSource source = new CancellationTokenSource())
                {
                    try
                    {
                        return await base.SendAsync(request, source.Token).ConfigureAwait(false);
                    }
                    catch (TaskCanceledException) when (tries++ < MaxTries)
                    {
                        Thread.Sleep(WaitInterval);
                    }
                }
            }
            while (true);
        }
    }
}