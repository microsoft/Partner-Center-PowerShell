// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Azure.Management.Billing;
    using Azure.Management.Billing.Models;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.Get, "PartnerAzureBillingAccount"), OutputType(typeof(BillingAccount))]
    public class GetPartnerAzureBillingAccount : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IBillingManagementClient client = await PartnerSession.Instance.ClientFactory.CreateServiceClientAsync<BillingManagementClient>(new[] { $"{PartnerSession.Instance.Context.Environment.AzureEndpoint}/user_impersonation" }).ConfigureAwait(false);
                BillingAccountListResult data = await client.BillingAccounts.ListAsync(null, CancellationToken).ConfigureAwait(false);

                WriteObject(data.Value, true);
            }, true);
        }
    }
}