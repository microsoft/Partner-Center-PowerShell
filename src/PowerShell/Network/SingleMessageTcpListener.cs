// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;

    /// <summary>
    /// Provides the ability to listen for a single message and respond.
    /// </summary>
    internal class SingleMessageTcpListener : IDisposable
    {
        /// <summary>
        /// Listens for connections from TCP network clients.
        /// </summary>
        private readonly TcpListener listener;

        /// <summary>
        /// The port on which to listen for incoming connection attempts.
        /// </summary>
        private readonly int port;

        /// <summary>
        /// A flag indicating if the object has already been disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleMessageTcpListener" /> class
        /// </summary>
        /// <param name="port">The port on which to listen for incoming connection attempts.</param>
        public SingleMessageTcpListener(int port)
        {
            port.AssertPositive(nameof(port));

            this.port = port;
            listener = new TcpListener(IPAddress.Loopback, this.port);
        }

        /// <summary>
        /// Listens for a single request and responds.
        /// </summary>
        /// <param name="producer"></param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns></returns>
        public async Task ListenToSingleRequestAndRespondAsync(Func<Uri, string> producer, CancellationToken cancellationToken)
        {
            TcpClient tcpClient = null;

            cancellationToken.Register(() => listener.Stop());
            listener.Start();

            try
            {
                tcpClient = await AcceptTcpClientAsync(cancellationToken).ConfigureAwait(false);
                await ExtractUriAndRespondAsync(tcpClient, producer, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                tcpClient?.Close();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                listener?.Stop();
            }

            disposed = true;
        }

        private async Task<TcpClient> AcceptTcpClientAsync(CancellationToken token)
        {
            try
            {
                return await listener.AcceptTcpClientAsync().ConfigureAwait(false);
            }
            catch (Exception ex) when (token.IsCancellationRequested)
            {
                throw new OperationCanceledException("Cancellation was requested while awaiting TCP client connection.", ex);
            }
        }

        private static async Task<string> GetTcpResponseAsync(TcpClient client, CancellationToken cancellationToken)
        {
            NetworkStream networkStream = client.GetStream();

            byte[] readBuffer = new byte[1024];
            StringBuilder stringBuilder = new StringBuilder();
            int numberOfBytesRead;

            do
            {
                numberOfBytesRead = await networkStream.ReadAsync(readBuffer, 0, readBuffer.Length, cancellationToken)
                    .ConfigureAwait(false);

                string s = Encoding.ASCII.GetString(readBuffer, 0, numberOfBytesRead);
                stringBuilder.Append(s);

            }
            while (networkStream.DataAvailable);

            return stringBuilder.ToString();
        }


        private async Task ExtractUriAndRespondAsync(TcpClient tcpClient, Func<Uri, string> responseProducer, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string httpRequest = await GetTcpResponseAsync(tcpClient, cancellationToken).ConfigureAwait(false);
            Uri uri = ExtractUriFromHttpRequest(httpRequest);

            await WriteResponseAsync(responseProducer(uri), tcpClient.GetStream(), cancellationToken).ConfigureAwait(false);
        }


        private Uri ExtractUriFromHttpRequest(string httpRequest)
        {
            Regex r1 = new Regex(@"GET \/\?(.*) HTTP");
            Match match = r1.Match(httpRequest);
            string getQuery;

            if (!match.Success)
            {
                throw new InvalidOperationException("Not a GET query.");
            }

            getQuery = match.Groups[1].Value;

            UriBuilder uriBuilder = new UriBuilder
            {
                Query = getQuery,
                Port = port
            };

            return uriBuilder.Uri;
        }

        private static async Task WriteResponseAsync(string message, NetworkStream stream, CancellationToken cancellationToken)
        {
            string fullResponse = $"HTTP/1.1 200 OK\r\n\r\n{message}";
            byte[] response = Encoding.ASCII.GetBytes(fullResponse);

            await stream.WriteAsync(response, 0, response.Length, cancellationToken).ConfigureAwait(false);
            await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}