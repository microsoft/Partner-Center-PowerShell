// -----------------------------------------------------------------------
// <copyright file="ICustomerLicensesDeploymentInsightsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using GenericOperations;
    using Models;
    using Models.Analytics;

    /// <summary>
    /// Encapsulates the operations on the customer's licenses' usage insights collection.
    /// </summary>
    public interface ICustomerLicensesUsageInsightsCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<CustomerLicensesUsageInsights, ResourceCollection<CustomerLicensesUsageInsights>>
    {
    }
}