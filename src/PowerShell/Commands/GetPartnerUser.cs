// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Graph;
    using Models.Authentication;
    using Network;
    using Properties;

    /// <summary>
    /// Command that gets partner level user accounts.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerUser"), OutputType(typeof(User))]
    public class GetPartnerUser : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the user.", Mandatory = false)]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the user principal name for the user.
        /// </summary>
        [Parameter(HelpMessage = "The user principal name for the user.", Mandatory = false)]
        [Alias("UPN")]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Operations that happen before the cmdlet is executed.
        /// </summary>
        protected override void BeginProcessing()
        {
            if (PartnerSession.Instance.Context == null)
            {
                throw new PSInvalidOperationException(Resources.RunConnectPartnerCenter);
            }

            base.BeginProcessing();
        }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                client.AuthenticationProvider = new GraphAuthenticationProvider();

                if (string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(UserPrincipalName))
                {
                    WriteObject(await GetUsersAsync(client).ConfigureAwait(false), true);
                }
                else
                {
                    WriteObject(await client.Users[string.IsNullOrEmpty(UserPrincipalName) ? UserId : UserPrincipalName].Request().GetAsync().ConfigureAwait(false));
                }
            });
        }

        private async Task<List<User>> GetUsersAsync(IGraphServiceClient client)
        {
            IGraphServiceUsersCollectionPage data = await client.Users.Request().GetAsync().ConfigureAwait(false);
            List<User> users = new List<User>(data.CurrentPage);

            while (data.NextPageRequest != null)
            {
                data = await data.NextPageRequest.GetAsync(CancellationToken).ConfigureAwait(false);
                users.AddRange(data.CurrentPage);
            }

            return users;
        }
    }
}