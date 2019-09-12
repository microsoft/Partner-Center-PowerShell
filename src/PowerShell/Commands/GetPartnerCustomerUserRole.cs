// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Roles;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Gets a list of roles for the specified customer user from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUserRole"), OutputType(typeof(PSDirectoryRole))]
    public class GetPartnerCustomerUserRole : PartnerPSCmdlet
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
            if (string.IsNullOrEmpty(UserId))
            {
                GetRole(CustomerId);
            }
            else
            {
                GetRole(CustomerId, UserId);
            }
        }

        /// <summary>
        /// Gets a list of roles from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userId">Identifier of the user.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="userId"/> is empty or null.
        /// </exception>
        private void GetRole(string customerId, string userId)
        {
            IEnumerable<DirectoryRole> roles;

            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            roles = Partner.Customers[customerId].Users[userId].DirectoryRoles.GetAsync().GetAwaiter().GetResult().Items;
            WriteObject(roles.Select(e => new PSDirectoryRole(e)), true);
        }

        /// <summary>
        /// Gets a list of customers from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetRole(string customerId)
        {
            IEnumerable<DirectoryRole> roles;

            customerId.AssertNotEmpty(nameof(customerId));

            roles = Partner.Customers[customerId].DirectoryRoles.GetAsync().GetAwaiter().GetResult().Items;
            WriteObject(roles.Select(e => new PSDirectoryRole(e)), true);
        }
    }
}