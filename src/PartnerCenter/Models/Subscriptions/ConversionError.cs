// -----------------------------------------------------------------------
// <copyright file="ConversionError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// Represents an error for the trial subscription conversion result.
    /// </summary>
    public sealed class ConversionError
    {
        /// <summary>
        /// Gets or sets the error code associated with the issue.
        /// </summary>
        public ConversionErrorCode Code { get; set; }

        /// <summary>
        /// Gets or sets the friendly text describing the error.
        /// </summary>
        public string Description { get; set; }
    }
}