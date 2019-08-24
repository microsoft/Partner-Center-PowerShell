// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Customers
{
    using Extensions;
    using PartnerCenter.Models.Customers;

    /// <summary>
    /// Represents a partner's customer.
    /// </summary>
    public sealed class PSCustomer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomer" /> class.
        /// </summary>
        public PSCustomer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomer" /> class.
        /// </summary>
        /// <param name="customer">The base customer for this instance.</param>
        public PSCustomer(Customer customer)
        {
            this.CopyFrom(customer, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets a value that indicates if delegated access is allowed for this customer or not.
        /// </summary>
        public bool? AllowDelegatedAccess { get; set; }

        /// <summary>
        /// Gets or sets the indirect reseller associated to this customer account.
        /// </summary>
        /// <remarks>
        /// This value can be set only by indirect CSP partners.
        /// </remarks>
        public string AssociatedPartnerId { get; set; }

        /// <summary>
        /// Gets or sets the customer's billing profile.
        /// </summary>
        public CustomerBillingProfile BillingProfile { get; set; }

        /// <summary>
        /// Gets or sets the commerce identifier.
        /// </summary>
        public string CommerceId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the Azure AD domain associated with the customer.
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the customer's relationship to partner.
        /// </summary>
        public CustomerPartnerRelationship RelationshipToPartner { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Customer" /> to an instance of <see cref="PSCustomer" />. 
        /// </summary>
        /// <param name="customer">The customer being cloned.</param>
        private void CloneAdditionalOperations(Customer customer)
        {
            CustomerId = customer.Id;
            Domain = customer?.CompanyProfile?.Domain;
            Name = customer?.CompanyProfile?.CompanyName;
        }
    }
}