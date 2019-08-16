// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// Get the activation link for the specified order line item from the partner service.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerOrderLineItemActivationLink")]
    [OutputType(typeof(OrderLineItemActivationLink))]
    public class GetPartnerCustomerOrderLineItemActivationLink : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the order.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the order line item number.
        /// </summary>
        [Parameter(HelpMessage = "The order line item number.", Mandatory = true)]
        [ValidateNotNull]
        public int OrderLineItemNumber { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            WriteObject(Partner.Customers[CustomerId].Orders[OrderId].OrderLineItems[OrderLineItemNumber].ActivationLink.GetAsync().GetAwaiter().GetResult().Items, true);
        }
    }
}