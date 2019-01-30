// -----------------------------------------------------------------------
// <copyright file="ICustomerUsageSpendingBudget.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using GenericOperations;
    using Models.Usage;

    /// <summary>
    /// Defines the operations available on a customer's usage spending budget.
    /// </summary>
    public interface ICustomerUsageSpendingBudget : IPartnerComponent<string>, IEntityGetOperations<SpendingBudget>, IEntityPatchOperations<SpendingBudget>
    {
    }
}