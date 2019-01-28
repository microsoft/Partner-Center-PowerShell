// -----------------------------------------------------------------------
// <copyright file="HttpContentType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.TestFramework.Network
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public sealed class HttpResponseRecords
    {
        /// <summary>
        /// A collection of HTTP operations.
        /// </summary>
        private readonly Dictionary<string, Queue<HttpResponseRecord>> sessionRecords;

        /// <summary>
        /// Provides the ability to map a request with it's corresponding response.
        /// </summary>
        private readonly IHttpRecordMatcher matcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseRecords" /> class.
        /// </summary>
        /// <param name="matcher">The matcher used to map a request with it's corresponding response.</param>
        public HttpResponseRecords(IHttpRecordMatcher matcher)
        {
            this.matcher = matcher;
            sessionRecords = new Dictionary<string, Queue<HttpResponseRecord>>();
        }

        public Queue<HttpResponseRecord> this[string key]
        {
            get => sessionRecords[key];
            set => sessionRecords[key] = value;
        }

        /// <summary>
        /// Gets the number of records contained in the collecion.
        /// </summary>
        public int Count => sessionRecords.Values.Select(q => q.Count).Sum();

        /// <summary>
        /// Gets all available records.
        /// </summary>
        /// <returns>All of the available records.</returns>
        public IEnumerable<HttpResponseRecord> GetAllEntities()
        {
            foreach (Queue<HttpResponseRecord> queues in sessionRecords.Values)
            {
                while (queues.Count > 0)
                {
                    yield return queues.Dequeue();
                }
            }
        }

        /// <summary>
        /// Adds an instance of the <see cref="HttpResponseRecord" /> class to the collection.
        /// </summary>
        /// <param name="record">The instance of the <see cref="HttpResponseRecord" /> class to be added.</param>
        public void Enqueue(HttpResponseRecord record)
        {
            string recordKey = matcher.GetMatchingKey(record);

            if (!sessionRecords.ContainsKey(recordKey))
            {
                sessionRecords[recordKey] = new Queue<HttpResponseRecord>();
            }

            sessionRecords[recordKey].Enqueue(record);
        }
    }
}