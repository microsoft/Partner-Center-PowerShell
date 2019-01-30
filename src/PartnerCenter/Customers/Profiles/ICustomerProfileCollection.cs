// -----------------------------------------------------------------------
// <copyright file="ICustomerProfileCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Profiles
{
    using Models.Customers;

    /// <summary>
    /// Holds the operations related to a customer's profiles.
    /// </summary>
    public interface ICustomerProfileCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the customer's billing profile operations.
        /// </summary>
        ICustomerProfile<CustomerBillingProfile> Billing { get; }

        /// <summary>
        /// Gets the customer's company profile operations.
        /// </summary>
        ICustomerReadonlyProfile<CustomerCompanyProfile> Company { get; }
    }
}