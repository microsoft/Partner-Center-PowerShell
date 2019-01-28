// -----------------------------------------------------------------------
// <copyright file="OrganizationProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    /// <summary>
    /// Represents a partner's organization profile.
    /// </summary>
    public sealed class OrganizationProfile : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationProfile" /> class.
        /// </summary>
        public OrganizationProfile()
        {
            DefaultAddress = new Address();
        }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the default address.
        /// </summary>
        public Address DefaultAddress { get; set; }

        /// <summary>
        /// Gets or sets the domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the profile identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        public string TenantId { get; set; }
    }
}