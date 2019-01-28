// -----------------------------------------------------------------------
// <copyright file="SimpleFieldFilter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System.Globalization;
    using Extensions;

    /// <summary>
    /// A simple filter applied to a field. An example is (Year lessThan 1999).
    /// </summary>
    public sealed class SimpleFieldFilter : FieldFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleFieldFilter" /> class.
        /// </summary>
        /// <param name="field">The filter field name</param>
        /// <param name="operation">The operator value.</param>
        /// <param name="value">The value to execute the operator on.</param>
        public SimpleFieldFilter(string field, FieldFilterOperation operation, string value)
        {
            field.AssertNotEmpty(nameof(field));
            value.AssertNotEmpty(nameof(value));
     
            Field = field;
            Value = value;
            Operator = operation;
        }

        /// <summary>
        /// Gets the filter field name.
        /// </summary>
        public string Field { get; private set; }

        /// <summary>
        /// Gets the filter value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Prints the simple filter details.
        /// </summary>
        /// <returns>The simple filter details.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "( {0} {1} {2} )", Field, Operator, Value);
        }
    }
}
