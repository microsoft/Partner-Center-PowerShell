// -----------------------------------------------------------------------
// <copyright file="CountQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    /// <summary>
    /// A query that returns the number of entities that may optionally fit a filter.
    /// </summary>
    internal class CountQuery : BaseQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountQuery" /> class.
        /// </summary>
        public CountQuery()
          : base(null)
        {
        }

        /// <summary>
        /// Gets the query type.
        /// </summary>
        public override QueryType Type => QueryType.Count;

        /// <summary>
        /// Gets or sets the query filter.
        /// </summary>
        public override FieldFilter Filter { get; set; }

        /// <summary>
        /// Returns a string representation of the query.
        /// </summary>
        /// <returns>
        /// A string representation of the query.
        /// </returns>
        public override string ToString()
        {
            if (Filter == null)
            {
                return base.ToString();
            }

            return Filter.ToString();
        }
    }
}