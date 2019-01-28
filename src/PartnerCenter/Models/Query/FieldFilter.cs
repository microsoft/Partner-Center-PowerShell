// -----------------------------------------------------------------------
// <copyright file="FieldFilter.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    /// <summary>
    /// A base class that represents a filter applied to a field.
    /// </summary>
    public abstract class FieldFilter
    {
        /// <summary>
        /// Gets or sets the filter operator.
        /// </summary>
        public FieldFilterOperation Operator { get; protected set; }
    }
}