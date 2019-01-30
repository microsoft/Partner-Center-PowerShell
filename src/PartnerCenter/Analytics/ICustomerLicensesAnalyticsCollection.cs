// -----------------------------------------------------------------------
// <copyright file="ICustomerLicensesAnalyticsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    /// <summary>
    /// Encapsulates collection of customer level analytics.
    /// </summary>
    public interface ICustomerLicensesAnalyticsCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Encapsulates customer level licenses deployment analytics.
        /// </summary>
        ICustomerLicensesDeploymentInsightsCollection Deployment { get; }

        /// <summary>
        /// Encapsulates customer level licenses usage analytics.
        /// </summary>
        ICustomerLicensesUsageInsightsCollection Usage { get; }
    }
}