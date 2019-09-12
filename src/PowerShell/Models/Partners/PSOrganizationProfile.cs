// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Partners
{
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Represents a partner's organization profile.
    /// </summary>
    public sealed class PSOrganizationProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrganizationProfile" /> class.
        /// </summary>
        public PSOrganizationProfile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOrganizationProfile" /> class.
        /// </summary>
        /// <param name="profile">The base organization profile for this instance.</param>
        public PSOrganizationProfile(OrganizationProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the company identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the organization name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the organization address.
        /// </summary>
        public Address DefaultAddress { get; set; }

        /// <summary>
        /// Gets or sets the tenant id.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Gets or sets the company default domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the company primary contact email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the company preferred language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the company preferred culture.
        /// </summary>
        public string Culture { get; set; }
    }
}