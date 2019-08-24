// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Customers
{
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Customers;

    /// <summary>
    /// Holds customer company profile information.
    /// </summary>
    public sealed class PSCustomerCompanyProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerCompanyProfile" /> class.
        /// </summary>
        public PSCustomerCompanyProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerCompanyProfile" /> class.
        /// </summary>
        /// <param name="profile">The base customer company profile for this instance.</param>
        public PSCustomerCompanyProfile(CustomerCompanyProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the address of the company.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the customer's Azure Active Directory domain.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or set the email address of the contact of the company.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Azure Active Directory tenant identifier for the customer's tenant.
        /// </summary>
        public string TenantId { get; set; }
    }
}