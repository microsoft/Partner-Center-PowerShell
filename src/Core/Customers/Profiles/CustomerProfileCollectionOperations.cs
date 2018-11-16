// -----------------------------------------------------------------------
// <copyright file="CustomerProfileCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Customers.Profiles
{
    using System;
    using Models.Customers;

    /// <summary>
    /// Implements customer profile collection operations.
    /// </summary>
    internal class CustomerProfileCollectionOperations : BasePartnerComponent, ICustomerProfileCollection, IPartnerComponent<string>
    {
        /// <summary>
        /// A lazy reference to a customer company operations instance.
        /// </summary>
        private readonly Lazy<ICustomerReadonlyProfile<CustomerCompanyProfile>> companyProfileOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProfileCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer tenant Id.</param>
        public CustomerProfileCollectionOperations(IPartner rootPartnerOperations, string customerId)
          : base(rootPartnerOperations, customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                throw new ArgumentException("customerId can't be null");
            }

            companyProfileOperations = new Lazy<ICustomerReadonlyProfile<CustomerCompanyProfile>>(
                () => new CustomerCompanyProfileOperations(Partner, Context));
        }

        /// <summary>
        /// Gets the customer's company profile operations.
        /// </summary>
        public ICustomerReadonlyProfile<CustomerCompanyProfile> Company => companyProfileOperations.Value;
    }
}