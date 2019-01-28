// -----------------------------------------------------------------------
// <copyright file="IPartnerLicensesAnalyticsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    /// <summary>
    /// Encapsulates collection of partner level licenses' analytics.
    /// </summary>
    public interface IPartnerLicensesAnalyticsCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the partner's licenses' deployment analytics.
        /// </summary>
        IPartnerLicensesDeploymentInsightsCollection Deployment { get; }

        /// <summary>
        /// Gets the partner's licenses' usage analytics.
        /// </summary>
        IPartnerLicensesUsageInsightsCollection Usage { get; }
    }
}