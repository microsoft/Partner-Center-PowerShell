// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Azure.Management.Billing;
    using Azure.Management.Billing.Models;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.Get, "PartnerAzureBillingPolicy")]
    [OutputType(typeof(CustomerPolicy))]
    public class GetPartnerAzureBillingPolicy : PartnerCmdlet
    {
        /// <summary>
        /// Gets or sets the name for the billing account.
        /// </summary>
        [Parameter(HelpMessage = "The name for the billing account.", Mandatory = true)]
        public string BillingAccountName { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IBillingManagementClient client = PartnerSession.Instance.ClientFactory.CreateServiceClient<BillingManagementClient>(new[] { $"{PartnerSession.Instance.Context.Environment.AzureEndpoint}/user_impersonation" });

            WriteObject(client.Policies.GetByCustomerAsync(BillingAccountName, CustomerId, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult());
        }
    }
}