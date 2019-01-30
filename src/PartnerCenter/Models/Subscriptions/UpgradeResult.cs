// -----------------------------------------------------------------------
// <copyright file="UpgradeErrorCode.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents the result of performing a subscription Upgrade.
    /// </summary>
    public sealed class UpgradeResult : ResourceBase
    {
        /// <summary>
        /// Gets or sets the errors encountered while attempting to migrate user licenses, if applicable.
        /// </summary>
        public IEnumerable<UserLicenseError> LicenseErrors { get; set; }

        /// <summary>
        /// Gets or sets the source subscription identifier.
        /// </summary>
        public string SourceSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the target subscription identifier.
        /// </summary>
        public string TargetSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the errors encountered while attempting to perform the upgrade, if applicable.
        /// </summary>
        public IEnumerable<UpgradeError> UpgradeErrors { get; set; }

        /// <summary>
        /// Gets or sets the type of upgrade.
        /// </summary>
        public UpgradeType UpgradeType { get; set; }
    }
}