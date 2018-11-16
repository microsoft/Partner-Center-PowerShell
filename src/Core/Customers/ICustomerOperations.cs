// -----------------------------------------------------------------------
// <copyright file="ICustomerOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Customers
{
    using GenericOperations;
    using Models.Customers;
    using Profiles;

    /// <summary>
    /// Groups operations that can be performed on a single partner customer.
    /// </summary>
    public interface ICustomerOperations : IPartnerComponent<string>, IEntityGetOperations<Customer>, IEntityDeleteOperations<Customer>, IEntityPatchOperations<Customer>
    {
        /// <summary>
        /// Gets the available customer profile operations.
        /// </summary>
        ICustomerProfileCollection Profiles { get; }
    }
}