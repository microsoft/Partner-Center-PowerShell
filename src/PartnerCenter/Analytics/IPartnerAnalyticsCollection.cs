// -----------------------------------------------------------------------
// <copyright file="IPartnerAnalyticsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    /// <summary>
    /// Encapsulates collection of partner's analytics.
    /// </summary>
    public interface IPartnerAnalyticsCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the partner's licenses analytics collection.
        /// </summary>
        IPartnerLicensesAnalyticsCollection Licenses { get; }
    }
}