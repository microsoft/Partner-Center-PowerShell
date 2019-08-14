// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using Models.Orders;

    /// <summary>
    /// Gets the provisioning status for the specified order.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerOrderProvisioningStatus")]
    [OutputType(typeof(PSOrderLineItemProvisioningStatus))]
    public class GetPartnerCustomerOrderProvisioningStatus : PartnerPSCmdlet
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
            WriteObject(Partner.Customers[CustomerId].Orders[OrderId].ProvisioningStatus.GetAsync().GetAwaiter().GetResult().Items.Select(s => new PSOrderLineItemProvisioningStatus(s)));
        }
    }
}
