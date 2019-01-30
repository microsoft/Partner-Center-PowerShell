// -----------------------------------------------------------------------
// <copyright file="IServiceCostSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.ServiceCosts
{
    using System;
    using GenericOperations;
    using Models;
    using Models.ServiceCosts;

    /// <summary>
    /// Represents the behavior of the customer service cost line items as a whole.
    /// </summary>
    public interface IServiceCostLineItemsCollection : IPartnerComponent<Tuple<string, ServiceCostsBillingPeriod>>, IEntireEntityCollectionRetrievalOperations<ServiceCostLineItem, ResourceCollection<ServiceCostLineItem>>
    {
    }
}