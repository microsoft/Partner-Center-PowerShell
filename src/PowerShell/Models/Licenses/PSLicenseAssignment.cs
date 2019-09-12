// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses
{
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using PartnerCenter.Models.Licenses;

    /// <summary>
    /// Model for licenses and service plans to be assigned to a user.
    /// </summary>
    public sealed class PSLicenseAssignment
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseAssignment" /> class.
        /// </summary>
        public PSLicenseAssignment()
        {
            ExcludedPlans = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseAssignment" /> class.
        /// </summary>
        /// <param name="licenseAssignment">The base license assignment for this instance.</param>
        public PSLicenseAssignment(LicenseAssignment licenseAssignment)
        {
            ExcludedPlans = new List<string>();
            this.CopyFrom(licenseAssignment, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the service plan identifiers which will not be assigned to the user.
        /// </summary>
        public List<string> ExcludedPlans { get; }

        /// <summary>
        /// Gets or sets product id to be assigned to the user.
        /// </summary>
        public string SkuId { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="LicenseAssignment"/> to an instance of <see cref="PSLicenseAssignment" />. 
        /// </summary>
        /// <param name="licenseAssignment">The license agreement being cloned.</param>
        private void CloneAdditionalOperations(LicenseAssignment licenseAssignment)
        {
            if (licenseAssignment.ExcludedPlans.Any())
            {
                ExcludedPlans.AddRange(licenseAssignment.ExcludedPlans);
            }
        }
    }
}