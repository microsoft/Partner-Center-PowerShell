// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerCompanyProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models.Customers;
    using PartnerCenter.PowerShell.Models.Customers;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerCompanyProfile"), OutputType(typeof(PSCustomerCompanyProfile))]
    public class GetPartnerCustomerCompanyProfile : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerCompanyProfile profile;

            try
            {
                profile = Partner.Customers[CustomerId].Profiles.Company.Get();

                WriteObject(new PSCustomerCompanyProfile(profile));
            }
            finally
            {
                profile = null;
            }
        }
    }
}