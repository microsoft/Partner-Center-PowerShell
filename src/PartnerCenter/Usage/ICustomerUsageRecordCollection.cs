// -----------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using GenericOperations;
    using Models;
    using Models.Usage;

    /// <summary>
    /// Defines the behavior of a customer usage record collection operations.
    /// </summary>
    public interface ICustomerUsageRecordCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<CustomerMonthlyUsageRecord, ResourceCollection<CustomerMonthlyUsageRecord>>
    {
    }
}