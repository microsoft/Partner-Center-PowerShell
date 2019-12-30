// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Usage;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Usage;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerUsageRecord")]
    [OutputType(typeof(PSCustomerUsageSummary))]
    public class GetPartnerCustomerUsageRecord : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<CustomerMonthlyUsageRecord> usageRecords = await partner.Customers.UsageRecords.GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(usageRecords.Items.Select(r => new PSCustomerMonthlyUsageRecord(r)), true);
            }, true);
        }
    }
}