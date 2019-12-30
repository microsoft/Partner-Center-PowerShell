// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Query;
    using PartnerCenter.Models.Users;
    using Properties;

    /// <summary>
    /// Gets a list of users for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsData.Restore, "PartnerCustomerUser", DefaultParameterSetName = "ByUserId", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RestorePartnerCustomerUser : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                string value = string.IsNullOrEmpty(UserId) ? UserPrincipalName : UserId;

                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RestorePartnerCustomerUserWhatIf, value)))
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                    string userId;

                    if (ParameterSetName.Equals("ByUpn", StringComparison.InvariantCultureIgnoreCase))
                    {
                        SimpleFieldFilter filter = new SimpleFieldFilter("UserState", FieldFilterOperation.Equals, "Inactive");
                        IQuery simpleQueryWithFilter = QueryFactory.BuildSimpleQuery(filter);
                        IResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>> usersEnumerator;
                        List<CustomerUser> users = new List<CustomerUser>();
                        SeekBasedResourceCollection<CustomerUser> seekUsers;

                        seekUsers = await partner.Customers[CustomerId].Users.QueryAsync(simpleQueryWithFilter, CancellationToken).ConfigureAwait(false);
                        usersEnumerator = partner.Enumerators.CustomerUsers.Create(seekUsers);

                        while (usersEnumerator.HasValue)
                        {
                            users.AddRange(usersEnumerator.Current.Items);
                            // TODO - Inject request context here.
                            await usersEnumerator.NextAsync(null, CancellationToken).ConfigureAwait(false);
                        }

                        CustomerUser user = users.SingleOrDefault(u => string.Equals(u.UserPrincipalName, UserPrincipalName, StringComparison.CurrentCultureIgnoreCase));

                        if (user == null)
                        {
                            throw new PSInvalidOperationException($"Unable to locate {UserPrincipalName}");
                        }

                        userId = user.Id;
                    }
                    else
                    {
                        userId = UserId;
                    }

                    CustomerUser updatedCustomerUser = new CustomerUser
                    {
                        State = UserState.Active
                    };

                    await partner.Customers.ById(CustomerId).Users.ById(userId).PatchAsync(updatedCustomerUser, CancellationToken).ConfigureAwait(false);
                }
            }, true);
        }
    }
}