// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Offers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Get an offer, or a list offers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerOffer")]
    [OutputType(typeof(PSOffer))]
    public class GetPartnerOffer : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                string countryCode = (string.IsNullOrEmpty(CountryCode)) ? PartnerSession.Instance.Context.CountryCode : CountryCode;

                if (!string.IsNullOrEmpty(Category) && string.IsNullOrEmpty(OfferId))
                {
                    ResourceCollection<Offer> offers = await partner.Offers.ByCountry(countryCode).ByCategory(Category).GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteOutput(offers.Items);
                }
                else if (string.IsNullOrEmpty(OfferId))
                {
                    ResourceCollection<Offer> offers = await partner.Offers.ByCountry(countryCode).GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteOutput(offers.Items);
                }
                else
                {
                    Offer offer = await partner.Offers.ByCountry(countryCode).ById(OfferId).GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(offer);
                }

            }, true);
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