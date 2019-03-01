// -----------------------------------------------------------------------
// <copyright file="AzureRateCardOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.RateCards
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Models.RateCards;

    /// <summary>
    /// Implements operations that apply to Azure rate card.
    /// </summary>
    internal class AzureRateCardOperations : BasePartnerComponent<string>, IAzureRateCard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureRateCardOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public AzureRateCardOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        /// <summary>
        /// Gets the Azure rate card which provides real-time prices for Azure offers.
        /// </summary>
        /// <param name="currency">An optional three letter ISO code for the currency in which the resource rates will be provided.
        /// The default is the currency associated with the market in the partner's profile.</param>
        /// <param name="region">An optional two-letter ISO country/region code that indicates the market where the offer is purchased.
        /// The default is the country/region code set in the partner profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The Azure rate card for the partner.</returns>
        public async Task<AzureRateCard> GetAsync(string currency = null, string region = null, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(currency))
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetAzureRateCard.Parameters.Currency,
                    currency);
            }

            if (!string.IsNullOrEmpty(region))
            {
                parameters.Add(
                  PartnerService.Instance.Configuration.Apis.GetAzureRateCard.Parameters.Region,
                  region);
            }

            return await Partner.ServiceClient.GetAsync<AzureRateCard>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAzureRateCard.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the Azure CSL rate card which provides real-time prices for Azure offers.
        /// </summary>
        /// <param name="currency">An optional three letter ISO code for the currency in which the resource rates will be provided.
        /// The default is the currency associated with the market in the partner's profile.</param>
        /// <param name="region">An optional two-letter ISO country/region code that indicates the market where the offer is purchased.
        /// The default is the country/region code set in the partner profile.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param
        /// <returns>The Azure rate card for the partner.</returns>
        public async Task<AzureRateCard> GetSharedAsync(string currency = null, string region = null, CancellationToken cancellationToken = default)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(currency))
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetAzureSharedRateCard.Parameters.Currency,
                    currency);
            }

            if (!string.IsNullOrEmpty(region))
            {
                parameters.Add(
                  PartnerService.Instance.Configuration.Apis.GetAzureSharedRateCard.Parameters.Region,
                  region);
            }

            return await Partner.ServiceClient.GetAsync<AzureRateCard>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAzureSharedRateCard.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}