// -----------------------------------------------------------------------
// <copyright file="LicenseAssignment.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Licenses
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for licenses and service plans to be assigned to a user.
    /// </summary>
    public sealed class LicenseAssignment
    {
        /// <summary>
        /// Gets or sets service plan ids which will not be assigned to the user.
        /// </summary>
        public IEnumerable<string> ExcludedPlans { get; set; }

        /// <summary>
        /// Gets or sets SKU identifier to be assigned to the user.
        /// </summary>
        public string SkuId { get; set; }
    }
}