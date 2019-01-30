// -----------------------------------------------------------------------
// <copyright file="FieldFilterOperation.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Query
{
    using System.ComponentModel;
    using Models.JsonConverters;
    using Newtonsoft.Json;

    /// <summary>
    /// Enumerates supported filter operations.
    /// </summary>
    [JsonConverter(typeof(EnumJsonConverter))]
    public enum FieldFilterOperation
    {
        /// <summary>
        /// Equals filter.
        /// </summary>
        [Description("=")] Equals,

        /// <summary>
        /// Not equals filter.
        /// </summary>
        [Description("<>")] NotEquals,

        /// <summary>
        /// Greater than filter.
        /// </summary>
        [Description(">")] GreaterThan,

        /// <summary
        /// >Greater than or equal filter.
        /// </summary>
        [Description(">=")] GreaterThanOrEquals,

        /// <summary>
        /// Less than filter.
        /// </summary>
        [Description("<")] LessThan,

        /// <summary>
        /// Less than or equals filter.
        /// </summary>
        [Description("<=")] LessThanOrEquals,

        /// <summary>
        /// Substring filter.
        /// </summary>
        [Description("Like")] Substring,

        /// <summary>
        /// And filter.
        /// </summary>
        [Description("&&")] And,

        /// <summary>
        /// Or filter.
        /// </summary>
        [Description("||")] Or,

        /// <summary>
        /// String starts with filter.
        /// </summary>
        [Description("StartsWith")] StartsWith,

        /// <summary>
        /// String does not starts with filter.
        /// </summary>
        [Description("NotStartsWith")] NotStartsWith,
    }
}