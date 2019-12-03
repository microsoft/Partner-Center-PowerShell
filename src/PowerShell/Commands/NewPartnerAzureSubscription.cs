// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Azure.Management.Profiles.Subscription;
    using Azure.Management.Profiles.Subscription.Models;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.New, "PartnerAzureSubscription", DefaultParameterSetName = ByCustomerNameParameterSet)]
    [OutputType(typeof(SubscriptionCreationResult))]
    public class NewPartnerAzureSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Name of the by customer identifier parameter set.
        /// </summary>
        private const string ByCustomerIdParameterSet = "ByCustomerId";

        /// <summary>
        /// Name of the by customer name parameter set.
        /// </summary>
        private const string ByCustomerNameParameterSet = "ByCustomerName";

        /// <summary>
        /// Gets or sets the name for the billing account.
        /// </summary>
        [Parameter(HelpMessage = "The name for the billing account.", Mandatory = true)]
        public string BillingAccountName { get; set; }

        /// <summary>
        /// Gets or sets the name for the customer.
        /// </summary>
        [BreakingChange("Replacing the customer name parameter with the customer identifier parameter.", "3.0.1", NewWay = "New-PartnerAzureSubscription -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerId '1e5a6ab0-e5ef-4f4e-a208-399e792b5ed4' -DisplayName 'Microsoft Azure'", OldWay = "New-PartnerAzureSubscription -BillingAccountName '99a13315-xxxx-xxxx-xxxx-xxxxxxxxxxxx:xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx_xxxx-xx-xx' -CustomerName 'Contoso' -DisplayName 'Microsoft Azure'")]
        [Parameter(HelpMessage = "The name of the customer.", Mandatory = true, ParameterSetName = ByCustomerNameParameterSet)]
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true, ParameterSetName = ByCustomerIdParameterSet)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

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

            if (ParameterSetName.Equals(ByCustomerIdParameterSet, StringComparison.InvariantCultureIgnoreCase))
            {
                WriteObject(client.SubscriptionFactory.CreateCspSubscriptionAsync(BillingAccountName, CustomerId, parameters, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
            }
            else
            {
                WriteObject(client.SubscriptionFactory.CreateCspSubscriptionAsync(BillingAccountName, CustomerName, parameters, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
            }
        }
    }
}