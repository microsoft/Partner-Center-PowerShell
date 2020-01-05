// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Graph;
    using Models.Authentication;
    using Network;
    using Properties;

    /// <summary>
    /// Gets a list of users for a customer from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "PartnerCustomerUser", DefaultParameterSetName = "ByUserId", SupportsShouldProcess = true)]
    [OutputType(typeof(bool))]
    public class RemovePartnerCustomerUser : PartnerAsyncCmdlet
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
        [ValidateNotNullOrEmpty]
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string value = string.IsNullOrEmpty(UserId) ? UserPrincipalName : UserId;

            Scheduler.RunTask(async () =>
            {
                if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.RemovePartnerCustomerUserWhatIf, value)))
                {
                    IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                    string userId;

                    if (ParameterSetName.Equals("ByUpn", StringComparison.InvariantCultureIgnoreCase))
                    {
                        GraphServiceClient client = PartnerSession.Instance.ClientFactory.CreateGraphServiceClient() as GraphServiceClient;
                        client.AuthenticationProvider = new GraphAuthenticationProvider(CustomerId);

                        User user = await client.Users[UserPrincipalName].Request().GetAsync(CancellationToken).ConfigureAwait(false);
                        userId = user.Id;
                    }
                    else
                    {
                        userId = UserId;
                    }

                    await partner.Customers.ById(CustomerId).Users.ById(userId).DeleteAsync(CancellationToken).ConfigureAwait(false);
                    WriteObject(true);
                }
            }, true);
        }
    }
}