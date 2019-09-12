// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.RateCards
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.RateCards;

    /// <summary>
    /// Provides real-time prices for Azure offers.
    /// </summary>
    public sealed class PSAzureRateCard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureRateCard" /> class.
        /// </summary>
        public PSAzureRateCard()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAzureRateCard" /> class.
        /// </summary>
        /// <param name="rateCard">The base rate card for this instance.</param>
        public PSAzureRateCard(AzureRateCard rateCard)
        {
            this.CopyFrom(rateCard);
        }

        /// <summary>
        /// Gets or sets the currency for the the meter rates.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the tax is included or not.
        /// </summary>
        public bool IsTaxIncluded { get; set; }

        /// <summary>
        /// Gets or sets the locale for the localizable properties in the rate card meters.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets a collection of meters.
        /// </summary>
        public IEnumerable<AzureMeter> Meters { get; set; }

        /// <summary>
        /// Gets or sets a collection of offer terms.
        /// </summary>
        public IEnumerable<AzureOfferTerm> OfferTerms { get; set; }
    }
}