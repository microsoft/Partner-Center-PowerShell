// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Microsoft.Graph;
    using Models.Authentication;
    using Models.Users;
    using Network;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Query;
    using PartnerCenter.Models.Users;
    using RequestContext;

    /// <summary>
    /// Gets a list of users for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUser", DefaultParameterSetName = "ByCustomerId")]
    [OutputType(typeof(PSCustomerUser))]
    public class GetPartnerCustomerUser : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByUserId", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByUserState", Mandatory = true, Position = 0, HelpMessage = "The identifier for the customer.")]
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
        [Parameter(ParameterSetName = "ByUserState", Mandatory = true, HelpMessage = "A flag that indicates whether or not to get deleted users.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ReturnDeletedUsers { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                if (ParameterSetName.Equals("ByUserId", StringComparison.InvariantCultureIgnoreCase))
                {
                    CustomerUser customerUser = await partner.Customers[CustomerId].Users[UserId].GetAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(new PSCustomerUser(customerUser));
                }
                else if (ParameterSetName.Equals("ByUserState", StringComparison.InvariantCultureIgnoreCase) && ReturnDeletedUsers.ToBool())
                {
                    SimpleFieldFilter filter = new SimpleFieldFilter("UserState", FieldFilterOperation.Equals, "Inactive");
                    IQuery simpleQueryWithFilter = QueryFactory.BuildSimpleQuery(filter);
                    IResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>> usersEnumerator;
                    List<CustomerUser> users;
                    SeekBasedResourceCollection<CustomerUser> seekUsers;

                    users = new List<CustomerUser>();

                    seekUsers = await partner.Customers[CustomerId].Users.QueryAsync(simpleQueryWithFilter, CancellationToken).ConfigureAwait(false);
                    usersEnumerator = partner.Enumerators.CustomerUsers.Create(seekUsers);

                    while (usersEnumerator.HasValue)
                    {
                        users.AddRange(usersEnumerator.Current.Items);
                        await usersEnumerator.NextAsync(RequestContextFactory.Create(CorrelationId), CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(users.Select(u => new PSCustomerUser(u)), true);
                }
                else if (ParameterSetName.Equals("ByUpn", StringComparison.InvariantCultureIgnoreCase))
                {
                    GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                    client.AuthenticationProvider = new GraphAuthenticationProvider(CustomerId);

                    Graph.User user = await client.Users[UserPrincipalName].Request().GetAsync(CancellationToken).ConfigureAwait(false);
                    CustomerUser customerUser = await partner.Customers[CustomerId].Users[user.Id].GetAsync(CancellationToken).ConfigureAwait(false);

                    WriteObject(customerUser);
                }
                else
                {
                    IResourceCollectionEnumerator<SeekBasedResourceCollection<CustomerUser>> usersEnumerator;
                    List<CustomerUser> users;
                    SeekBasedResourceCollection<CustomerUser> seekUsers;

                    users = new List<CustomerUser>();

                    seekUsers = await partner.Customers[CustomerId].Users.GetAsync(CancellationToken).ConfigureAwait(false);
                    usersEnumerator = partner.Enumerators.CustomerUsers.Create(seekUsers);

                    while (usersEnumerator.HasValue)
                    {
                        users.AddRange(usersEnumerator.Current.Items);
                        await usersEnumerator.NextAsync(RequestContextFactory.Create(CorrelationId), CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(users.Select(u => new PSCustomerUser(u)), true);
                }
            }, true);
        }
    }
}