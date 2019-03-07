// -----------------------------------------------------------------------
// <copyright file="GetPartnerCountryValidation.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.ValidationRules;

    [Cmdlet(VerbsCommon.Get, "PartnerCountryValidation"), OutputType(typeof(PSCountryValidationRules))]
    public class GetPartnerCountryValidation : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the country code in ISO2 format.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The country code in ISO2 format.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(new PSCountryValidationRules(Partner.CountryValidationRules.ByCountry(CountryCode).GetAsync().GetAwaiter().GetResult()));
        }
    }
}