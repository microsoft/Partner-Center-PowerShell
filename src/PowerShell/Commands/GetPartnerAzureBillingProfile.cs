// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Azure.Management.Billing;
    using Azure.Management.Billing.Models;
    using Models.Authentication;
    using Rest.Azure;

    [Cmdlet(VerbsCommon.Get, "PartnerAzureBillingProfile"), OutputType(typeof(BillingAccount))]
    public class GetPartnerAzureBillingProfile : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or set the name for the billing account.
        /// </summary>
        [Parameter(HelpMessage = "The name for the billing account", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string BillingAccountName { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IBillingManagementClient client = await PartnerSession.Instance.ClientFactory.CreateServiceClientAsync<BillingManagementClient>(new[] { $"{PartnerSession.Instance.Context.Environment.AzureEndpoint}//user_impersonation" });
                IPage<Customer> data = client.Customers.ListByBillingAccountAsync(BillingAccountName, null, null, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult();

                WriteObject(data, true);
            }, true);
        }
    }
}