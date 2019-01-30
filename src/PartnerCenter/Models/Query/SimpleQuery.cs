// -----------------------------------------------------------------------
// <copyright file="SimpleQuery.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System.Text;

    /// <summary>
    /// A standard query that returns entities according to sort and filter options (Does not do paging).
    /// </summary>
    internal class SimpleQuery : BaseQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleQuery" /> class.
        /// </summary>
        public SimpleQuery()
          : base(null)
        {
        }

        /// <summary>
        /// Gets the query type.
        /// </summary>
        public override QueryType Type => QueryType.Simple;

        /// <summary>
        /// Gets or sets the query filter.
        /// </summary>
        public override FieldFilter Filter { get; set; }

        /// <summary>
        /// Gets or sets the query sorting options.
        /// </summary>
        public override Sort Sort { get; set; }

        /// <summary>
        /// Returns a string representation of the query.
        /// </summary>
        /// <returns>
        /// A string representation of the query.
        /// </returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (Sort != null)
            {
                stringBuilder.AppendLine(Sort.ToString());
            }

            if (Filter != null)
            {
                stringBuilder.AppendLine(Filter.ToString());
            }

            string str = stringBuilder.ToString();

            if (!string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return base.ToString();
        }
    }
}