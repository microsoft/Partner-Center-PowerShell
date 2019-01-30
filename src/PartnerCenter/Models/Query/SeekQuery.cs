// -----------------------------------------------------------------------
// <copyright file="SeekQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    /// <summary>
    /// Represents a seek query. The seek query can be used to seek through sets of results using the given seek operation.
    /// </summary>
    internal class SeekQuery : IndexedQuery
    {
        /// <summary>
        /// Gets the query type.
        /// </summary>
        public override QueryType Type => QueryType.Seek;

        /// <summary>
        /// Gets or sets the seek operation.
        /// </summary>
        public override SeekOperation SeekOperation { get; set; }
    }
}