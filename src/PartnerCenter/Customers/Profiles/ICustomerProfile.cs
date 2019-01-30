// -----------------------------------------------------------------------
// <copyright file="ICustomerProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Profiles
{
    using GenericOperations;
    using Models;

    /// <summary>
    /// Encapsulates a single customer profile behavior.
    /// </summary>
    /// <typeparam name="T">The type of the customer profile.</typeparam>
    public interface ICustomerProfile<T> : ICustomerReadonlyProfile<T>, IEntityUpdateOperations<T, T>
      where T : ResourceBase
    {
    }
}