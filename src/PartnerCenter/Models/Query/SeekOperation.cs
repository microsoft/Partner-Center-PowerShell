// -----------------------------------------------------------------------
// <copyright file="SeekOperation.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    /// <summary>
    /// Specifies how to seek a query.
    /// </summary>
    public enum SeekOperation
    {
        /// <summary>
        /// Gets the next set of results.
        /// </summary>
        Next,

        /// <summary>
        /// Gets the previous set of results.</summary>
        Previous,

        /// <summary>
        /// Gets the first set of results.
        /// </summary>
        First,

        /// <summary>
        /// Gets the last set of results.
        /// </summary>
        Last,

        /// <summary>
        /// Gets a set of results using a page index. E.g. Get the seventh set of results.
        /// </summary>
        PageIndex
    }
}