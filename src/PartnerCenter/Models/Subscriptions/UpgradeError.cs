// -----------------------------------------------------------------------
// <copyright file="UpgradeError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// Represents an error for subscription upgrade eligibility.
    /// </summary>
    public sealed class UpgradeError
    {
        /// <summary>
        /// Gets or sets additional details regarding the error.
        /// </summary>
        public string AdditionalDetails { get; set; }

        /// <summary>
        /// Gets or sets the error code associated with the issue.
        /// </summary>
        public UpgradeErrorCode Code { get; set; }

        /// <summary>
        /// Gets or sets the friendly text describing the error.
        /// </summary>
        public string Description { get; set; }
    }
}