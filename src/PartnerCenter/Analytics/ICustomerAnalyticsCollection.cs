// -----------------------------------------------------------------------
// <copyright file="ICustomerAnalyticsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Analytics
{
    /// <summary>
    /// Represents the customer analytics collection operations.
    /// </summary>
    public interface ICustomerAnalyticsCollection : IPartnerComponent<string>
    {
        /// <summary>Gets the customer's licenses analytics collection.</summary>
        ICustomerLicensesAnalyticsCollection Licenses { get; }
    }
}