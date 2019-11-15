// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Azure.Management.Billing;
    using Azure.Management.Billing.Models;
    using Models.Authentication;

    [Cmdlet(VerbsCommon.Get, "PartnerAzureBillingAccount"), OutputType(typeof(BillingAccount))]
    public class GetPartnerAzureBillingAccount : PartnerPSCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            IBillingManagementClient client = PartnerSession.Instance.ClientFactory.CreateServiceClient<BillingManagementClient>(new[] { "https://management.azure.com//user_impersonation" });

            WriteObject(client.BillingAccounts.ListAsync(null, CancellationToken).ConfigureAwait(false).GetAwaiter().GetResult().Value, true);
        }
    }
}