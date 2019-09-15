// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Network
{
    using System.Net.Http;

    /// <summary>
    /// Interface that used by the mock server for mapping a request with it's corresponding response.
    /// </summary>
    public interface IHttpRecordMatcher
    {
        /// <summary>
        /// Gets the key used for mapping a given record request's with its response.
        /// </summary>
        /// <param name="record">The record entry containing the request info</param>
        /// <returns>The key used for the mapping.</returns>
        string GetMatchingKey(HttpResponseRecord record);

        /// <summary>
        /// Gets the key mapping for the given request.
        /// </summary>
        /// <param name="request">The request to be mapped.</param>
        /// <returns>The key corresponding to this request.</returns>
        string GetMatchingKey(HttpRequestMessage request);
    }
}