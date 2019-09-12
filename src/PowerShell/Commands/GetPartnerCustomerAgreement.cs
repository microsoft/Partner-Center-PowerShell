// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Agreements;

    /// <summary>
    /// Gets a list of agreements the customer in place.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerAgreement"), OutputType(typeof(PSAgreement))]
    public class GetPartnerCustomerAgreement : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the agreement type. 
        /// </summary>
        [Parameter(HelpMessage = "The type of agreement of being requested.", Mandatory = false)]
        [ValidateSet("MicrosoftCloudAgreement", "MicrosoftCustomerAgreement")]
        public string AgreementType { get; set; }

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
            if (string.IsNullOrEmpty(AgreementType))
            {
                WriteObject(Partner.Customers[CustomerId].Agreements.GetAsync().GetAwaiter().GetResult().Items.Select(a => new PSAgreement(a)), true);
            }
            else
            {
                WriteObject(Partner.Customers[CustomerId].Agreements.ByAgreementType(AgreementType).GetAsync().GetAwaiter().GetResult().Items.Select(a => new PSAgreement(a)), true);
            }
        }
    }
}