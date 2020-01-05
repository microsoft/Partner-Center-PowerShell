// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Rest;

    /// <summary>
    /// Provides the ability to listen and intercept HTTP operations.
    /// </summary>
    internal class HttpListenerInterceptor
    {
        /// <summary>
        /// Listens for a single request and responds.
        /// </summary>
        /// <param name="port">The port where to listen for requests.</param>
        /// <param name="responseProducer">The function responsible for responding.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task<Uri> ListenToSingleRequestAndRespondAsync(int port, Func<Uri, MessageAndHttpCode> responseProducer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            HttpListener httpListener = null;

            try
            {
                string urlToListenTo = $"http://localhost:{port}/";

                httpListener = new HttpListener();
                httpListener.Prefixes.Add(urlToListenTo);

                httpListener.Start();
                ServiceClientTracing.Information($"[HttpListenerInterceptor] Listening for authorization code on {urlToListenTo}");

                using (cancellationToken.Register(() =>
                {
                    TryStopListening(httpListener);
                }))
                {
                    HttpListenerContext context = await httpListener.GetContextAsync().ConfigureAwait(false);

                    cancellationToken.ThrowIfCancellationRequested();

                    Respond(responseProducer, context);
                    ServiceClientTracing.Information($"[HttpListenerInterceptor] Received a message on {urlToListenTo}");

                    // the request URL should now contain the auth code and pkce
                    return context.Request.Url;
                }
            }
            catch (ObjectDisposedException)
            {
                cancellationToken.ThrowIfCancellationRequested();

                throw;
            }
            finally
            {
                TryStopListening(httpListener);
            }
        }

        private static void Respond(Func<Uri, MessageAndHttpCode> responseProducer, HttpListenerContext context)
        {
            MessageAndHttpCode messageAndCode = responseProducer(context.Request.Url);
            ServiceClientTracing.Information($"[HttpListenerInterceptor] Processing a response message to the browser. HttpStatus: {messageAndCode.HttpCode}");

            switch (messageAndCode.HttpCode)
            {
                case HttpStatusCode.Found:
                    context.Response.StatusCode = (int)HttpStatusCode.Found;
                    context.Response.RedirectLocation = messageAndCode.Message;
                    break;
                case HttpStatusCode.OK:
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(messageAndCode.Message);
                    context.Response.ContentLength64 = buffer.Length;
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    break;
                default:
                    throw new NotImplementedException("HttpCode not supported" + messageAndCode.HttpCode);
            }

            context.Response.OutputStream.Close();
        }

        private static void TryStopListening(HttpListener httpListener)
        {
            try
            {
                httpListener?.Abort();
            }
            catch
            {
                // Exceptions with this operation can safely be ignored.
            }
        }
    }
}