// -----------------------------------------------------------------------
// <copyright file="IPartnerLicensesUsageInsightsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using GenericOperations;
    using Models;
    using Models.Analytics;

    /// <summary>
    /// Encapsulates the operations on the partner's licenses' usage insights collection.
    /// </summary>
    public interface IPartnerLicensesUsageInsightsCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<PartnerLicensesUsageInsights, ResourceCollection<PartnerLicensesUsageInsights>>
    {
    }
}