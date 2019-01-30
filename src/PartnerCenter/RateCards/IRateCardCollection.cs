// -----------------------------------------------------------------------
// <copyright file="IRateCardCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RateCards
{
    /// <summary>
    /// Holds operations that apply to rate cards.
    /// </summary>
    public interface IRateCardCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the Azure rate card operations.
        /// </summary>
        IAzureRateCard Azure { get; }
    }
}