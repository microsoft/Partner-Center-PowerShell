// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerAgreement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Authentication;
    using Models.Agreements;

    /// <summary>
    /// Gets a list of agreements the customer in place.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerAgreement"), OutputType(typeof(PSAgreement))]
    public class GetPartnerCustomerAgreement : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the types of authentication supported by the command.
        /// </summary>
        public override AuthenticationTypes SupportedAuthentication => AuthenticationTypes.AppPlusUser;

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
            WriteObject(Partner.Customers[CustomerId].Agreements.Get().Items.Select(a => new PSAgreement(a)), true);
        }
    }
}