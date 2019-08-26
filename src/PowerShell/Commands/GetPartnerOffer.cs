// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Extensions;
    using Models.Authentication;
    using Models.Offers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Get an offer, or a list offers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerOffer"), OutputType(typeof(PSOffer))]
    public class GetPartnerOffer : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the switch indicating whether or not to scope the results to add-ons.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Scope returned offers to only add-ons.")]
        public SwitchParameter AddOn { get; set; }

        /// <summary>
        /// Gets or sets the offer category.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Category that corresponds to the offers.")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the country code used to obtain offers.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The country ISO2 code.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "A GUID that corresponds to the offer.")]
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the switch indicating whether or not to scope the results to trials.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Scope returned offers to only trials.")]
        public SwitchParameter Trial { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

            if (!string.IsNullOrEmpty(Category) && string.IsNullOrEmpty(OfferId))
            {
                GetOffersByCategory(countryCode, Category);
            }
            else if (string.IsNullOrEmpty(OfferId))
            {
                GetOffers(countryCode);
            }
            else
            {
                GetOffer(countryCode, OfferId);
            }
        }

        /// <summary>
        /// Gets the specified offer.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offer.</param>
        /// <param name="offerId">Identifier for the offer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// or
        /// <paramref name="offerId"/> is empty or null.
        /// </exception>
        private void GetOffer(string countryCode, string offerId)
        {
            Offer offer;

            countryCode.AssertNotEmpty(nameof(countryCode));
            offerId.AssertNotEmpty(nameof(offerId));

            offer = Partner.Offers.ByCountry(countryCode).ById(offerId).GetAsync().GetAwaiter().GetResult();
            WriteObject(new PSOffer(offer));
        }

        /// <summary>
        /// Gets a list of offers available for the specified country.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offers.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="countryCode"/> is empty or null.
        /// </exception>
        private void GetOffers(string countryCode)
        {
            ResourceCollection<Offer> offers;

            countryCode.AssertNotEmpty(nameof(countryCode));

            offers = Partner.Offers.ByCountry(countryCode).GetAsync().GetAwaiter().GetResult();
            WriteOutput(offers.Items);
        }

        /// <summary>
        /// Gets a list of offers by country and category.
        /// </summary>
        /// <param name="countryCode">The country used to obtain the offers.</param>
        /// <param name="category">The category for the offers.</param>
        private void GetOffersByCategory(string countryCode, string category)
        {
            ResourceCollection<Offer> offers;

            countryCode.AssertNotEmpty(nameof(countryCode));
            category.AssertNotEmpty(nameof(category));

            offers = Partner.Offers.ByCountry(countryCode).ByCategory(category).GetAsync().GetAwaiter().GetResult();
            WriteOutput(offers.Items);
        }

        /// <summary>
        /// Helper method to write a list of offers.
        /// </summary>
        /// <param name="offers">List of offers to be written to the output.</param>
        private void WriteOutput(IEnumerable<Offer> offers)
        {
            bool isAddOn = AddOn.IsPresent && AddOn.ToBool();
            bool isTrial = Trial.IsPresent && Trial.ToBool();

            WriteObject(
                offers
                    .Where(o => o.IsAddOn == isAddOn && o.IsTrial == isTrial)
                    .Select(o => new PSOffer(o)), true);
        }
    }
}