// -----------------------------------------------------------------------
// <copyright file="GetPartnerOfferCategory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Offers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Get an offer, or a list offers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerOfferCategory"), OutputType(typeof(PSOfferCategory))]
    public class GetPartnerOfferCategory : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the country code used to obtain offers.
        /// </summary>
        [Parameter(HelpMessage = "The country ISO2 code.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string CountryCode { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<OfferCategory> offerCategories = Partner.OfferCategories.ByCountry(CountryCode).Get();

            WriteObject(offerCategories.Items.Select(c => new PSOfferCategory(c)));
        }
    }
}