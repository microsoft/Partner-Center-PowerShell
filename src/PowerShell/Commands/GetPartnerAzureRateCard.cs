// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.RateCards;
    using PartnerCenter.Models.RateCards;

    /// <summary>
    /// Cmdlet that retrieves Azrue Rate Card details.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerAzureRateCard"), OutputType(typeof(PSAzureRateCard))]
    public class GetPartnerAzureRateCard : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An optional three letter ISO code for the currency in which the resource rates will be provided.")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or sets the offer category.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "An optional two-letter ISO country/region code that indicates the market where the offer is purchased.")]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not to retrieve the Azure Rate Card for Azure Partner Shared Services (APSS).
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Flag indicating whether or not to retrieve the Azure Rate Card for Azure Partner Shared Services (APSS).")]
        public SwitchParameter SharedServices { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            AzureRateCard rateCard;

            if (SharedServices.IsPresent && SharedServices.ToBool())
            {
                rateCard = Partner.RateCards.Azure.GetSharedAsync(Currency, Region).GetAwaiter().GetResult();
            }
            else
            {
                rateCard = Partner.RateCards.Azure.GetAsync(Currency, Region).GetAwaiter().GetResult();
            }

            WriteObject(new PSAzureRateCard(rateCard));
        }
    }
}