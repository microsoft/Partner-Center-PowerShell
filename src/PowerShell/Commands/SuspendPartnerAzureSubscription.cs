// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Azure.Management.Profiles.Subscription;
    using Azure.Management.Profiles.Subscription.Models;
    using Models.Authentication;

    [Cmdlet(VerbsLifecycle.Suspend, "PartnerAzureSubscription")]
    [OutputType(typeof(string))]
    public class SuspendPartnerAzureSubscription : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the subscription.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                ISubscriptionClient client = await PartnerSession.Instance.ClientFactory.CreateServiceClientAsync<SubscriptionClient>(
                    new[] { $"{PartnerSession.Instance.Context.Environment.AzureEndpoint}//user_impersonation" },
                    CustomerId).ConfigureAwait(false);

                CanceledSubscriptionId response = await client.Subscriptions.CancelAsync(
                    SubscriptionId,
                    true,
                    CancellationToken).ConfigureAwait(false);

                WriteObject(response);
            }, true);
        }
    }
}
