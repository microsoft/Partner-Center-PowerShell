// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerUserLicense.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Licenses;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Licenses;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUserLicense"), OutputType(typeof(PSLicense))]
    public class GetPartnerCustomerUserLicense : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the license group identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the license group.", Mandatory = false)]
        [ValidateSet(nameof(LicenseGroupId.Group1), nameof(LicenseGroupId.Group2))]
        public LicenseGroupId[] LicenseGroup { get; set; }

        /// <summary>
        /// Gets or sets the required user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the user.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<License> licenses;

            try
            {
                licenses = Partner.Customers[CustomerId].Users[UserId].Licenses.Get(LicenseGroup?.Select(item => item).ToList());
                WriteObject(licenses.Items.Select(l => new PSLicense(l)), true);
            }
            finally
            {
                licenses = null;
            }
        }
    }
}