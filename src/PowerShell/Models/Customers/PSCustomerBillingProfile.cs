// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.


namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Customers
{
    using Extensions;
    using PartnerCenter.Models;

    /// <summary>
    /// The customer billing profile information.
    /// </summary>
    public sealed class PSCustomerBillingProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerBillingProfile" /> class.
        /// </summary>
        public PSCustomerBillingProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerBillingProfile" /> class.
        /// </summary>
        /// <param name="profile">The base customer for this instance.</param>
        public PSCustomerBillingProfile(PartnerCenter.Models.Customers.CustomerBillingProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the  name of the company.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// Gets or sets the default address for customer.
        /// </summary>
        public Address DefaultAddress { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary
        /// >Gets or sets the profile identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }
}