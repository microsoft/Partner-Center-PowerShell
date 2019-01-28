// -----------------------------------------------------------------------
// <copyright file="LicenseWarning.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Licenses
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for license warnings.
    /// </summary>
    public sealed class LicenseWarning
    {
        /// <summary>
        /// Gets or sets the warning code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the warning message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the list of service plan names.
        /// </summary>
        public IEnumerable<string> ServicePlans { get; set; }
    }
}
