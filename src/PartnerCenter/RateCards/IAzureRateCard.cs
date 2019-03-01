// -----------------------------------------------------------------------
// <copyright file="GetPartnerAzureRateCard.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RateCards
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models.RateCards;

    /// <summary>
    /// Holds operations that apply to Azure rate card.
    /// </summary>
    public interface IAzureRateCard : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the Azure rate card which provides real-time prices for Azure offers.
        /// </summary>
        /// <param name="currency">An optional three letter ISO code for the currency in which the resource rates will be provided.
        /// The default is the currency associated with the market in the partner's profile.</param>
        /// <param name="region">An optional two-letter ISO country/region code that indicates the market where the offer is purchased.
        /// The default is the country/region code set in the partner profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The Azure rate card for the partner.</returns>
        Task<AzureRateCard> GetAsync(string currency = null, string region = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the Azure CSL rate card which provides real-time prices for Azure offers.
        /// </summary>
        /// <param name="currency">An optional three letter ISO code for the currency in which the resource rates will be provided.
        /// The default is the currency associated with the market in the partner's profile.</param>
        /// <param name="region">An optional two-letter ISO country/region code that indicates the market where the offer is purchased.
        /// The default is the country/region code set in the partner profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param
        /// <returns>The Azure rate card for the partner.</returns>
        Task<AzureRateCard> GetSharedAsync(string currency = null, string region = null, CancellationToken cancellationToken = default);
    }
}
