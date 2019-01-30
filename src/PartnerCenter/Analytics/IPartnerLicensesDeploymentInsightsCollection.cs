// -----------------------------------------------------------------------
// <copyright file="IPartnerLicensesDeploymentInsightsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    using GenericOperations;
    using Models;
    using Models.Analytics;

    /// <summary>
    /// Encapsulates the operations on the partner's licenses' deployment insights collection.
    /// </summary>
    public interface IPartnerLicensesDeploymentInsightsCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<PartnerLicensesDeploymentInsights, ResourceCollection<PartnerLicensesDeploymentInsights>>
    {
    }
}