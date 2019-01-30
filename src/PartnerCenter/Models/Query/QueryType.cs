// -----------------------------------------------------------------------
// <copyright file="QueryType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    /// <summary>
    /// Enumerates query types.
    /// </summary>
    public enum QueryType
    {
        /// <summary>
        /// A standard query that supports filtering and sorting.
        /// </summary>
        Simple,

        /// <summary>
        /// A query that supports paging using an index and a page size in addition to the standard filtering and sorting.
        /// </summary>
        Indexed,

        /// <summary>
        /// A query that returns the count of results according to an optional filter.
        /// </summary>
        Count,

        /// <summary>
        /// A query that is a continuation of a previous one. Used to retrieve more records of the same query relative to the last made query by seeking to pages.
        /// </summary>
        Seek
    }
}