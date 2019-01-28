// -----------------------------------------------------------------------
// <copyright file="CustomerProfileCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Profiles
{
    using System;
    using Extensions;
    using Models.Customers;

    /// <summary>
    /// Implements customer profile collection operations.
    /// </summary>
    internal class CustomerProfileCollectionOperations : BasePartnerComponent<string>, ICustomerProfileCollection
    {
        /// <summary>
        /// Provides access to the customer billing operations.
        /// </summary>
        private readonly Lazy<ICustomerProfile<CustomerBillingProfile>> billingProfile;

        /// <summary>
        /// Provides access to the customer company operations.
        /// </summary>
        private readonly Lazy<ICustomerReadonlyProfile<CustomerCompanyProfile>> companyProfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProfileCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        public CustomerProfileCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            customerId.AssertNotEmpty(nameof(customerId));

            billingProfile = new Lazy<ICustomerProfile<CustomerBillingProfile>>(() => new CustomerBillingProfileOperations(rootPartnerOperations, customerId));
            companyProfile = new Lazy<ICustomerReadonlyProfile<CustomerCompanyProfile>>(() => new CustomerCompanyProfileOperations(rootPartnerOperations, customerId));
        }

        /// <summary>
        /// Gets the customer's billing profile operations.
        /// </summary>
        public ICustomerProfile<CustomerBillingProfile> Billing => billingProfile.Value;

        /// <summary>
        /// Gets the customer's company profile operations.
        /// </summary>
        public ICustomerReadonlyProfile<CustomerCompanyProfile> Company => companyProfile.Value;
    }
}