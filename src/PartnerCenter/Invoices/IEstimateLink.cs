// -----------------------------------------------------------------------
// <copyright file="IEstimateLink.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    /// <summary>
    /// Represents the operations available to an estimate link.
    /// </summary>
    public interface IEstimateLink
    {
        /// <summary>
        /// Retrieves the operations that can be applied on products from a given country.
        /// </summary>
        /// <param name="currencyCode">The country name.</param>
        /// <returns>The product collection operations by country.</returns>
        IEstimateLinkCollectionByCurrency ByCurrency(string currencyCode);
    }
}