// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System.Collections.Generic;

    public sealed class HttpResponseRecords
    {
        /// <summary>
        /// A collection of HTTP operations.
        /// </summary>
        private readonly Dictionary<string, HttpResponseRecord> sessionRecords;

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
            sessionRecords = new Dictionary<string, HttpResponseRecord>();
        }

        public HttpResponseRecord this[string key]
        {
            get => sessionRecords[key];
            set => sessionRecords[key] = value;
        }

        /// <summary>
        /// Gets the number of records contained in the collecion.
        /// </summary>
        public int Count => sessionRecords.Count;

        /// <summary>
        /// Gets all available records.
        /// </summary>
        /// <returns>All of the available records.</returns>
        public IEnumerable<HttpResponseRecord> GetAllEntities()
        {
            foreach (HttpResponseRecord record in sessionRecords.Values)
            {
                yield return record;
            }
        }

        /// <summary>
        /// Adds an instance of the <see cref="HttpResponseRecord" /> class to the collection.
        /// </summary>
        /// <param name="record">The instance of the <see cref="HttpResponseRecord" /> class to be added.</param>
        public void Enqueue(HttpResponseRecord record)
        {
            sessionRecords[matcher.GetMatchingKey(record)] = record;
        }
    }
}