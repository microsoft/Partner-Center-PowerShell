// -----------------------------------------------------------------------
// <copyright file="ICustomerUsageSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using GenericOperations;
    using Models.Usage;

    /// <summary>
    /// Defines the operations available on a customer's usage summary.
    /// </summary>
    public interface ICustomerUsageSummary : IPartnerComponent<string>, IEntityGetOperations<CustomerUsageSummary>
    {
    }
}