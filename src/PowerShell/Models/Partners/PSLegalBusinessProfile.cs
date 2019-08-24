// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Partners
{
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Represents a partner's legal business profile.
    /// </summary>
    public sealed class PSLegalBusinessProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLegalBusinessProfile" /> class.
        /// </summary>
        public PSLegalBusinessProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLegalBusinessProfile" /> class.
        /// </summary>
        /// <param name="profile">The base legal business profile for this instance.</param>
        public PSLegalBusinessProfile(LegalBusinessProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the legal business organization name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the legal business address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the primary contact.
        /// </summary>
        public Contact PrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the address of the company approver.
        /// </summary>
        public Address CompanyApproverAddress { get; set; }

        /// <summary>
        /// Gets or sets the email of the company approver.
        /// </summary>
        public string CompanyApproverEmail { get; set; }

        /// <summary>
        /// Gets or sets the verification status.
        /// </summary>
        public VettingStatus VettingStatus { get; set; }

        /// <summary>
        /// Gets or sets the verification sub-status.
        /// </summary>
        public VettingSubStatus VettingSubStatus { get; set; }
    }
}