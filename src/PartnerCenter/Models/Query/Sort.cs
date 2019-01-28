// -----------------------------------------------------------------------
// <copyright file="Sort.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System.Globalization;
    using Extensions;

    /// <summary>
    /// Specifies sort field and direction.
    /// </summary>
    public sealed class Sort
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sort" /> class.
        /// </summary>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortDirection">The sort direction.</param>
        public Sort(string sortField, SortDirection sortDirection = SortDirection.Ascending)
        {
            sortField.AssertNotEmpty(nameof(sortField));

            SortField = sortField;
            SortDirection = sortDirection;
        }

        /// <summary>
        /// Gets the sort field.
        /// </summary>
        public string SortField { get; private set; }

        /// <summary>
        /// Gets the sort direction.
        /// </summary>
        public SortDirection SortDirection { get; private set; }

        /// <summary>
        /// Prints the sort details.
        /// </summary>
        /// <returns>
        /// The sort details.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "Sort: {0}, {1}", SortField, SortDirection);
        }
    }
}
