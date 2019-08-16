// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Roles;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Gets the members for the specified partner roles.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerRoleMember"), OutputType(typeof(PSUserMember))]
    public class GetPartnerRoleMember : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the role.", Mandatory = false, Position = 0)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string RoleId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            SeekBasedResourceCollection<UserMember> members = Partner.Roles[RoleId].Members.GetAsync().GetAwaiter().GetResult();

            WriteObject(members.Items.Select(m => new PSUserMember(m)), true);
        }
    }
}