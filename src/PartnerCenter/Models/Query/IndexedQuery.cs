// -----------------------------------------------------------------------
// <copyright file="IndexedQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System;
    using System.Globalization;
    using System.Text;

    /// <summary>
    /// A query that supports pagination. Use this for huge datasets.
    /// </summary>
    internal class IndexedQuery : SimpleQuery
    {
        /// <summary>
        /// The starting index of the results to return.
        /// </summary>
        private int index;

        /// <summary>
        /// The number of results to return.
        /// </summary>
        private int pageSize;

        /// <summary>
        /// Gets the query type.
        /// </summary>
        public override QueryType Type => QueryType.Indexed;

        /// <summary>
        /// Gets or sets the starting index of the results to return.
        /// </summary>
        public override int Index
        {
            get => index;
            set => index = Math.Max(value, 0);
        }

        /// <summary>
        /// Gets or sets the number of results to return.
        /// </summary>
        public override int PageSize
        {
            get => pageSize;
            set => pageSize = Math.Max(value, 0);
        }

        /// <summary>
        /// Returns a string representation of the query.
        /// </summary>
        /// <returns>A string representation of the query.</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(string.Format(CultureInfo.InvariantCulture, "Index: {0}, Page size: {1}", Index, PageSize));
            stringBuilder.AppendLine(base.ToString());
            return stringBuilder.ToString();
        }
    }
}