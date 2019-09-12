// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Licenses;

    public sealed class PSLicenseUpdate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseUpdate" /> class.
        /// </summary>
        public PSLicenseUpdate()
        {
            LicensesToAssign = new List<PSLicenseAssignment>();
            LicensesToRemove = new List<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicenseUpdate" /> class.
        /// </summary>
        /// <param name="licenseUpdate">The based license update for this instance.</param>
        public PSLicenseUpdate(LicenseUpdate licenseUpdate)
        {
            LicensesToAssign = new List<PSLicenseAssignment>();
            LicensesToRemove = new List<string>();

            this.CopyFrom(licenseUpdate);
        }

        /// <summary>
        /// Gets or sets the list of licenses to be assigned.
        /// </summary>
        public List<PSLicenseAssignment> LicensesToAssign { get; }

        /// <summary>
        /// Gets the list of license identifiers.to be removed.
        /// </summary>
        public List<string> LicensesToRemove { get; }
    }
}
