// -----------------------------------------------------------------------
// <copyright file="CustomerCompanyProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models.Customers
{
    /// <summary>
    /// Holds customer company profile information.
    /// </summary>
    public sealed class CustomerCompanyProfile : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the company address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or set the email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the domain of the customer's Azure AD tenant.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer's Azure AD tenant.
        /// </summary>
        public string TenantId { get; set; }
    }
}