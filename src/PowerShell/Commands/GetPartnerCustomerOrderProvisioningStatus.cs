// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.Orders;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// Gets the provisioning status for the specified order.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerOrderProvisioningStatus")]
    [OutputType(typeof(PSOrderLineItemProvisioningStatus))]
    public class GetPartnerCustomerOrderProvisioningStatus : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the customer.", Mandatory = true)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the order.", Mandatory = true)]
        public string OrderId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<OrderLineItemProvisioningStatus> status = await partner.Customers[CustomerId].Orders[OrderId].ProvisioningStatus.GetAsync(CancellationToken).ConfigureAwait(false);

                WriteObject(status.Items.Select(s => new PSOrderLineItemProvisioningStatus(s)));
            }, true);
        }
    }
}
