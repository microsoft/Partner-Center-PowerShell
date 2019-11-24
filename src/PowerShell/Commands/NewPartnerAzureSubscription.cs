// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Azure.Management.Profiles.Subscription;
    using Azure.Management.Profiles.Subscription.Models;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.New, "PartnerAzureSubscription"), OutputType(typeof(SubscriptionCreationResult))]
    public class NewPartnerAzureSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the name for the billing account.
        /// </summary>
        [Parameter(HelpMessage = "The name for the billing account.", Mandatory = true)]
        public string BillingAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name for the customer.
        /// </summary>
        [Parameter(HelpMessage = "The name for the customer.", Mandatory = true)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the display name for the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The display for the subscription.", Mandatory = true)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or set the identifier for the indirect reseller.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the indirect reseller.", Mandatory = false)]
        public string ResellerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ISubscriptionClient client = PartnerSession.Instance.ClientFactory.CreateServiceClient<SubscriptionClient>(new[] { $"{PartnerSession.Instance.Context.Environment.AzureEndpoint}/user_impersonation" });
            ModernCspSubscriptionCreationParameters parameters = new ModernCspSubscriptionCreationParameters
            {
                DisplayName = DisplayName,
                ResellerId = ResellerId ?? null,
                SkuId = "0001"
            };

            WriteObject(client.SubscriptionFactory.CreateCspSubscriptionAsync(BillingAccountName, CustomerName, parameters, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }
    }
}