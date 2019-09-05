// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using PartnerCenter.Models.Roles;
    using PartnerCenter.Models.Users;

    /// <summary>
    /// Gets a list of roles for the specified customer user from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "PartnerCustomerUserRoleMember"), OutputType(typeof(bool))]
    public class AddPartnerCustomerUserRoleMember : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier for the customer user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the role  identifier.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier for the role.")]
        [ValidateNotNull]
        public string RoleId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            UserId.AssertNotEmpty(nameof(UserId));
            RoleId.AssertNotEmpty(nameof(RoleId));

            CustomerUser user = GetUserById(CustomerId, UserId);

            UserMember newMember = new UserMember()
            {
                UserPrincipalName = user.UserPrincipalName,
                DisplayName = user.DisplayName,
                Id = user.Id
            };

            Partner.Customers[CustomerId].DirectoryRoles[RoleId].UserMembers.CreateAsync(newMember).GetAwaiter().GetResult();
            WriteObject(true);

        }

        /// <summary>
        /// Gets details for a specified user and customer from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userId">Identifier of the user.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private CustomerUser GetUserById(string customerId, string userId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            return Partner.Customers[customerId].Users[userId].GetAsync().GetAwaiter().GetResult(); ;

        }
    }
}