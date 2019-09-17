// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Exceptions;
    using Newtonsoft.Json;
    using PartnerCenter.Models.JsonConverters;

    /// <summary>
    /// A mock delegating handler used for testing HTTP server interactions.
    /// </summary>
    public class HttpMockHandler : DelegatingHandler
    {
        /// <summary>
        /// The name of the session records directory.
        /// </summary>
        private const string SessionsDirectory = "SessionRecords";

        /// <summary>
        /// Used to ensure that entries are enqueued in a thread safe fashion.
        /// </summary>
        private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Provides the ability to map a request with it's corresponding response.
        /// </summary>
        private readonly IHttpRecordMatcher matcher;

        /// <summary>
        /// A collection of the <see cref="HttpResponseRecord" /> class that represent the HTTP operations performed.
        /// </summary>
        private readonly HttpResponseRecords records;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMockHandler" /> class.
        /// </summary>
        /// <param name="mode">The mode of the mock server.</param>
        public HttpMockHandler(HttpMockHandlerMode mode)
        {
            Mode = mode;
            matcher = new HttpRecordMatcher("x-ms-version");
            records = new HttpResponseRecords(matcher);

            Initialize();
        }

        /// <summary>
        /// Gets the mode for the mock handler.
        /// </summary>
        public HttpMockHandlerMode Mode { get; }

        /// <summary>
        /// Sends a HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The response from the HTTP operation.</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            string key;

            if (Mode == HttpMockHandlerMode.Playback)
            {
                lock (records)
                {
                    key = matcher.GetMatchingKey(request);

                    if (records[key] == null)
                    {
                        throw new ResponseNotFoundException($"Unable to locate a reponse for {key}");
                    }

                    response = records[matcher.GetMatchingKey(request)].GetResponse();
                    response.RequestMessage = request;

                    return response;
                }
            }
            else
            {
                try
                {
                    await Semaphore.WaitAsync().ConfigureAwait(false);

                    response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

                    lock (records)
                    {
                        records.Enqueue(new HttpResponseRecord(response));
                    }

                    return response;
                }
                finally
                {
                    Semaphore.Release();
                }
            }
        }

        public void Flush(string identity)
        {
            List<HttpResponseRecord> processedRecords;
            JsonSerializer serializer;
            string location;

            if (Mode == HttpMockHandlerMode.Record && records.Count > 0)
            {
                processedRecords = new List<HttpResponseRecord>();

                lock (records)
                {
                    foreach (HttpResponseRecord response in records.GetAllEntities())
                    {
                        response.RequestHeaders.Remove("Authorization");
                        response.RequestHeaders.Remove("MS-ContinuationToken");
                        processedRecords.Add(response);
                    }
                }

                serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    TypeNameHandling = TypeNameHandling.None
                };

                serializer.Converters.Add(new EnumJsonConverter());
                location = Path.Combine(AppContext.BaseDirectory, SessionsDirectory);

                if (!Directory.Exists(location))
                {
                    Directory.CreateDirectory(location);
                }

                using (StreamWriter writer = File.CreateText(Path.Combine(location, $"{identity}.json")))
                {
                    serializer.Serialize(writer, processedRecords);
                }
            }
        }

        private void Initialize()
        {
            List<HttpResponseRecord> processed;
            JsonSerializer serializer;
            string location;

            if (Mode == HttpMockHandlerMode.Playback)
            {
                serializer = new JsonSerializer
                {
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    TypeNameHandling = TypeNameHandling.None
                };

                processed = new List<HttpResponseRecord>();

#if FullNetFx
                location = Path.Combine(Assembly.GetCallingAssembly().Location, SessionsDirectory); 
#else
                location = Path.Combine(AppContext.BaseDirectory, SessionsDirectory);
#endif

                foreach (string fileName in Directory.GetFiles(location))
                {
                    using (StreamReader reader = File.OpenText(fileName))
                    {
                        using (JsonReader jsonReader = new JsonTextReader(reader))
                        {
                            processed.AddRange(serializer.Deserialize<List<HttpResponseRecord>>(jsonReader));
                        }
                    }
                }

                lock (records)
                {
                    foreach (HttpResponseRecord record in processed)
                    {
                        records.Enqueue(record);
                    }
                }
            }
        }
    }
}