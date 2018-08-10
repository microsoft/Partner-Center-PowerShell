// -----------------------------------------------------------------------
// <copyright file="GetPartnerCountryValidation5.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.CountryValidationRules;
    using PartnerCenter.Models.CountryValidationRules;

    [Cmdlet(VerbsCommon.Get, "PartnerCountryValidation"), OutputType(typeof(PSCountryValidationRules))]
    public class GetPartnerCountryValidation : PartnerPSCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The country code in ISO2 format.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CountryValidationRules rules;

            try
            {
                rules = Partner.CountryValidationRules.ByCountry(CountryCode).Get();
                WriteObject(new PSCountryValidationRules(rules));
            }
            finally
            {
                rules = null;
            }
        }
    }
}