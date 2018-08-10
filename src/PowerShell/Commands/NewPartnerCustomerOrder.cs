// -----------------------------------------------------------------------
// <copyright file="NewPartnerCustomerOrder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using PartnerCenter.Models.Orders;
    using PartnerCenter.PowerShell.Models.Orders;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerOrder", SupportsShouldProcess = true), OutputType(typeof(PSOrder))]
    public class NewPartnerCustomerOrder : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer making the purchase.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order line items. Each order line item refers to one offer's purchase data.
        /// </summary>
        [Parameter(HelpMessage = "The order line items. Each order line item refers to one offer's purchase data.", Mandatory = true)]
        public PSOrderLineItem[] LineItems { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Order newOrder;

            try
            {
                newOrder = new Order
                {
                    LineItems = LineItems.Select(o => o.ToOrderLineItem()),
                    ReferenceCustomerId = CustomerId
                };

                newOrder = Partner.Customers[CustomerId].Orders.Create(newOrder);

                WriteObject(new PSOrder(newOrder));
            }
            finally
            {
                newOrder = null;
            }
        }
    }
}