// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models.ApplicationConsents;

    /// <summary>
    /// Create a new application consent for the specified customer.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "PartnerCustomerApplicationConsent"), OutputType(typeof(ApplicationConsent))]
    public class NewPartnerCustomerApplicationConsent : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the application grants.
        /// </summary>
        [Parameter(HelpMessage = "The grants for the application.", Mandatory = true)]
        [ValidateNotNull]
        public ApplicationGrant[] ApplicationGrants { get; set; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for application.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the display name of the application.
        /// </summary>
        [Parameter(HelpMessage = "The display name for the application.", Mandatory = true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ApplicationConsent consent = new ApplicationConsent
            {
                ApplicationId = ApplicationId,
                DisplayName = DisplayName
            };

            consent.ApplicationGrants.AddRange(ApplicationGrants);

            consent = Partner.Customers[CustomerId].ApplicationConsents.CreateAsync(consent).GetAwaiter().GetResult();

            WriteObject(consent);
        }
    }
}