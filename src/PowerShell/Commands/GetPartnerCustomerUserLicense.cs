// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Licenses;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Licenses;

    /// <summary>
    /// Command that gets the licenses assigned to a user from a customer.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUserLicense")]
    [OutputType(typeof(PSLicense))]
    public class GetPartnerCustomerUserLicense : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
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
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync().ConfigureAwait(false);

                ResourceCollection<License> licenses = await partner.Customers[CustomerId]
                    .Users[UserId].Licenses.GetAsync(LicenseGroup?.Select(item => item).ToList()).ConfigureAwait(false);

                WriteObject(licenses.Items.Select(l => new PSLicense(l)), true);
            }, true);

        }
    }
}