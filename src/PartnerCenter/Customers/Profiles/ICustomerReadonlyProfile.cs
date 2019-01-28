// -----------------------------------------------------------------------
// <copyright file="ICustomerReadonlyProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Profiles
{
    using GenericOperations;
    using Models;

    /// <summary>
    /// Encapsulates a single customer readonly profile behavior.
    /// </summary>
    /// <typeparam name="T">The type of the customer profile.</typeparam>
    public interface ICustomerReadonlyProfile<T> : IPartnerComponent<string>, IEntityGetOperations<T> where T : ResourceBase
    {
    }
}