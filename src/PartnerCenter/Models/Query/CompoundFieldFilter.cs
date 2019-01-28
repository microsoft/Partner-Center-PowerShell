// -----------------------------------------------------------------------
// <copyright file="CompoundFieldFilter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System;
    using System.Globalization;

    /// <summary>
    /// An aggregated filter. Example: (Year = 1999 AND Model = Nissan).
    /// </summary>
    public sealed class CompoundFieldFilter : FieldFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundFieldFilter" /> class.
        /// </summary>
        /// <param name="leftFilter">The left filter.</param>
        /// <param name="operation">The operation.</param>
        /// <param name="rightFilter">The right filter.</param>
        public CompoundFieldFilter(FieldFilter leftFilter, FieldFilterOperation operation, FieldFilter rightFilter)
        {
            LeftFilter = leftFilter ?? throw new ArgumentException("leftFilter cannot be null");
            Operator = operation;
            RightFilter = rightFilter ?? throw new ArgumentException("rightFilter cannot be null");
        }

        /// <summary>
        /// Gets the left filter.
        /// </summary>
        public FieldFilter LeftFilter { get; private set; }

        /// <summary>
        /// Gets the right filter.
        /// </summary>
        public FieldFilter RightFilter { get; private set; }

        /// <summary>
        /// Prints the compound filter details.
        /// </summary>
        /// <returns>The compound filter details.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "( {0} {1} {2} )", LeftFilter, Operator, RightFilter);
        }
    }
}
