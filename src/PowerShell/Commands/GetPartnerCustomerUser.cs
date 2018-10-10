﻿// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Exceptions;
    using Models.CustomerUsers;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Query;
    using PartnerCenter.Models.Users;

    /// <summary>
    /// Gets a list of users for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUser", DefaultParameterSetName = "ByCustomerId"), OutputType(typeof(PSCustomerUser))]
    public class GetPartnerCustomerUser : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
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
        [Parameter(ParameterSetName = "ByUpn", Mandatory = true, HelpMessage = "The user principal name (UPN) for the user.")]
        [ValidateNotNullOrEmpty]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Gets or sets the optional user identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = false, HelpMessage = "A flag that indicates whether or not to show deleted users.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ReturnDeletedUsers { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case "ByCustomerId":
                    if (ReturnDeletedUsers)
                    {
                        List<CustomerUser> users = GetDeletedUsers(CustomerId);
                        WriteObject(users.Select(u => new PSCustomerUser(u)), true);
                    }
                    else
                    {
                        List<CustomerUser> users = GetUsers(CustomerId);
                        WriteObject(users.Select(u => new PSCustomerUser(u)), true);
                    }

                    break;
                case "ByUpn":
                    GetUserByUpn(CustomerId, UserPrincipalName);
                    break;
                case "ByUserId":
                    GetUserById(CustomerId, UserId);
                    break;
            }
        }

        /// <summary>
        /// Gets a details for a specified user and customer from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userId">Identifier of the user.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetUserById(string customerId, string userId)
        {
            CustomerUser user;

            customerId.AssertNotEmpty(nameof(customerId));
            userId.AssertNotEmpty(nameof(userId));

            try
            {
                user = Partner.Customers[customerId].Users[userId].Get();
                WriteObject(new PSCustomerUser(user));
            }
            catch (PSPartnerException ex)
            {
                throw new PSPartnerException("Error finding user:" + userId, ex);
            }
            finally
            {
                user = null;
            }
        }

        /// <summary>
        /// Gets a list of users from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private List<CustomerUser> GetUsers(string customerId)
        {
            IResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>> usersEnumerator;
            List<CustomerUser> users;
            SeekBasedResourceCollection<CustomerUser> seekUsers;

            customerId.AssertNotEmpty(nameof(customerId));

            try
            {
                users = new List<CustomerUser>();

                seekUsers = Partner.Customers[customerId].Users.Get();
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
                seekUsers = null;
                usersEnumerator = null;
            }
        }

        /// <summary>
        /// Gets a list of deleted users from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <exception cref="ArgumentException">
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

        /// <summary>
        /// Gets a list of users by searching for the user principal name from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="userPrincipalName">Identifier of the user principal name.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetUserByUpn(string customerId, string userPrincipalName)
        {

            customerId.AssertNotEmpty(nameof(customerId));
            customerId.AssertNotEmpty(nameof(userPrincipalName));

            List<CustomerUser> gUsers = GetUsers(customerId);
            try
            {
                CustomerUser fUser = gUsers.Where(u => string.Equals(u.UserPrincipalName, userPrincipalName, StringComparison.CurrentCultureIgnoreCase)).First<CustomerUser>();
                WriteObject(new PSCustomerUser(fUser));
            }
            catch
            {
                throw new PSPartnerException("Error finding user id for " + userPrincipalName);
            }

        }

    }
}