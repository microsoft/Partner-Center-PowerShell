// -----------------------------------------------------------------------
// <copyright file="SortDirection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System.ComponentModel;

    /// <summary>
    /// Specifies sort direction.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// Ascending sort.
        /// </summary>
        [Description("asc")] Ascending,

        /// <summary>
        /// Descending sort.
        /// </summary>
        [Description("desc")] Descending
    }
}