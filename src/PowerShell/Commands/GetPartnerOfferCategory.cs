// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Offers;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Get an offer, or a list offers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerOfferCategory")]
    [OutputType(typeof(PSOfferCategory))]
    public class GetPartnerOfferCategory : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<OfferCategory> offerCategories = await partner.OfferCategories.ByCountry(CountryCode).GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(offerCategories.Items.Select(c => new PSOfferCategory(c)));
            }, true);
        }
    }
}