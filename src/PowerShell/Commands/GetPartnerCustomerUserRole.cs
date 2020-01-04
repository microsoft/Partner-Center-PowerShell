// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Roles;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Gets a list of roles for the specified customer user from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUserRole")]
    [OutputType(typeof(PSDirectoryRole))]
    public class GetPartnerCustomerUserRole : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the optional user identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier for the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<DirectoryRole> roles;

                if (string.IsNullOrEmpty(UserId))
                {
                    roles = await partner.Customers[CustomerId].DirectoryRoles.GetAsync(CancellationToken).ConfigureAwait(false);
                }
                else
                {
                    roles = await partner.Customers[CustomerId].Users[UserId].DirectoryRoles.GetAsync(CancellationToken).ConfigureAwait(false);
                }

                WriteObject(roles.Items.Select(r => new PSDirectoryRole(r)), true);
            }, true);
        }
    }
}