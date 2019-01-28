// -----------------------------------------------------------------------
// <copyright file="IServiceCostSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using GenericOperations;
    using Models.ServiceCosts;

    /// <summary>
    /// This interface defines the operations available on a customer's service cost summary.
    /// </summary>
    public interface IServiceCostSummary : IPartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>, IEntityGetOperations<ServiceCostsSummary>
    {
    }
}
