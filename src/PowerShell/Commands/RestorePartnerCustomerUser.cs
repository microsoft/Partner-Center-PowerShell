// -----------------------------------------------------------------------
// <copyright file="RestorePartnerCustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Exceptions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Query;
    using PartnerCenter.Models.Users;
    using PartnerCenter.PowerShell.Exceptions;
    using Properties;

    /// <summary>
    /// Gets a list of users for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "PartnerCustomerUser", DefaultParameterSetName = "ByUserId", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RestorePartnerCustomerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByUserId", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByUpn", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the optional user identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByUserId", Mandatory = true, HelpMessage = "The identifier for the user.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the optional user principal name.
        /// </summary>
        [Parameter(ParameterSetName = "ByUpn", Mandatory = true, HelpMessage = "The user principal name for the user.")]
        [ValidateNotNull]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RestorePartnerCustomerUserWhatIf, UserId)))
            {
                switch (ParameterSetName)
                {
                    case "ByUpn":
                        RestoreUserByUpn(CustomerId, UserPrincipalName);
                        break;
                    case "ByUserId":
                        RestoreUserById(CustomerId, UserId);
                        break;
                }
            }
        }

        /// <summary>
        /// Restores the specified customer user id.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userId">Identifier of the user.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void RestoreUserById(string customerId, string userId)
        {
            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            CustomerUser updatedCustomerUser = new CustomerUser
            {
                State = UserState.Active
            };

            try
            {
                Partner.Customers.ById(customerId).Users.ById(userId).Patch(updatedCustomerUser);
                WriteObject(true);
            }
            catch (PartnerException ex)
            {
                throw new PSPartnerException("Error restoring user id: " + userId, ex);
            }
            finally
            {
                customerId = null;
                userId = null;
            }
        }

        /// <summary>
        /// Restores the customer user from Partner Center based on the specified user principal name.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userPrincipalName">Identifier of the user principal name.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void RestoreUserByUpn(string customerId, string userPrincipalName)
        {
            customerId.AssertNotEmpty(nameof(customerId));
            customerId.AssertNotEmpty(nameof(userPrincipalName));

            RestoreUserById(customerId, GetUserIdByUpn(customerId, userPrincipalName));
        }

        /// <summary>
        /// Gets a user id by searching for the user principal name from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userPrincipalName">Identifier of the user principal name.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private string GetUserIdByUpn(string customerId, string userPrincipalName)
        {
            customerId.AssertNotEmpty(nameof(customerId));
            customerId.AssertNotEmpty(nameof(userPrincipalName));

            List<CustomerUser> gUsers = GetDeletedUsers(customerId);

            try
            {
                return (gUsers.Where(u => string.Equals(u.UserPrincipalName, userPrincipalName, StringComparison.CurrentCultureIgnoreCase)).First<CustomerUser>()).Id;
            }
            catch
            {
                throw new PSPartnerException("Error finding user id for " + userPrincipalName);
            }
        }

        /// <summary>
        /// Gets a list of deleted users from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private List<CustomerUser> GetDeletedUsers(string customerId)
        {
            SimpleFieldFilter filter = new SimpleFieldFilter("UserState", FieldFilterOperation.Equals, "Inactive");
            IQuery simpleQueryWithFilter = QueryFactory.Instance.BuildSimpleQuery(filter);
            IResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>> usersEnumerator;
            List<CustomerUser> users;
            SeekBasedResourceCollection<CustomerUser> seekUsers;

            customerId.AssertNotEmpty(nameof(customerId));

            try
            {
                users = new List<CustomerUser>();

                seekUsers = Partner.Customers[customerId].Users.Query(simpleQueryWithFilter);
                usersEnumerator = Partner.Enumerators.CustomerUsers.Create(seekUsers);
                while (usersEnumerator.HasValue)
                {
                    users.AddRange(usersEnumerator.Current.Items);
                    usersEnumerator.Next();
                }

                return users;
            }
            finally
            {
                users = null;
                seekUsers = null;
                usersEnumerator = null;
            }
        }
    }
}