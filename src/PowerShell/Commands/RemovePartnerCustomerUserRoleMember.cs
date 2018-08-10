// -----------------------------------------------------------------------
// <copyright file="RemovePartnerCustomerUserRoleMember.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Exceptions;

    /// <summary>
    /// Gets a list of roles for the specified customer user from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerCustomerUserRoleMember"), OutputType(typeof(bool))]
    public class RemovePartnerCustomerUserRoleMember : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier of the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the role  identifier.
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

            try
            {
                Partner.Customers[CustomerId].DirectoryRoles[RoleId].UserMembers[UserId].Delete();
                WriteObject(true);
            }
            catch (PSPartnerException ex)
            {
                throw new PSPartnerException("Error removing user " + UserId + "from role " + RoleId, ex);
            }
            finally
            {
            }
        }
    }
}