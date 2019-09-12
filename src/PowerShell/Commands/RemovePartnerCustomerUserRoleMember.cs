// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;

    /// <summary>
    /// Removes the user from the specified role.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerCustomerUserRoleMember"), OutputType(typeof(bool))]
    public class RemovePartnerCustomerUserRoleMember : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier of the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Identifier for the role.")]
        public string RoleId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            CustomerId.AssertNotEmpty(nameof(CustomerId));
            UserId.AssertNotEmpty(nameof(UserId));
            RoleId.AssertNotEmpty(nameof(RoleId));

            Partner.Customers[CustomerId].DirectoryRoles[RoleId].UserMembers[UserId].DeleteAsync().GetAwaiter().GetResult();
            WriteObject(true);
        }
    }
}