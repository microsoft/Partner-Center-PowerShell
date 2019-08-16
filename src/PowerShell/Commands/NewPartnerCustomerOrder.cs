// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Orders;
    using PartnerCenter.PowerShell.Models.Orders;

    [Cmdlet(VerbsCommon.New, "PartnerCustomerOrder", DefaultParameterSetName = SubscriptionParameterSet, SupportsShouldProcess = true)]
    [OutputType(typeof(PSOrder))]
    public class NewPartnerCustomerOrder : PartnerPSCmdlet
    {
        /// <summary>
        /// The name for the add-on parameter set. 
        /// </summary>
        private const string AddOnParameterSet = "AddOn";

        /// <summary>
        /// The name for the subscription parameter set.
        /// </summary>
        private const string SubscriptionParameterSet = "Subscription";

        /// <summary>
        /// Gets or sets the billing cycle type.
        /// </summary>
        [Parameter(HelpMessage = "The frequency with which the partner is billed for this order.", Mandatory = false)]
        [ValidateSet(nameof(BillingCycleType.Annual), nameof(BillingCycleType.Monthly), nameof(BillingCycleType.None))]
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer making the purchase.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true, ParameterSetName = AddOnParameterSet)]
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true, ParameterSetName = SubscriptionParameterSet)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order line items. Each order line item refers to one offer's purchase data.
        /// </summary>
        [Parameter(HelpMessage = "The order line items. Each order line item refers to one offer's purchase data.", Mandatory = true, ParameterSetName = AddOnParameterSet)]
        [Parameter(HelpMessage = "The order line items. Each order line item refers to one offer's purchase data.", Mandatory = true, ParameterSetName = SubscriptionParameterSet)]
        public PSOrderLineItem[] LineItems { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        [Parameter(HelpMessage = "The order identifier used when purchasing an add-on.", Mandatory = true, ParameterSetName = AddOnParameterSet)]
        public string OrderId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<OrderLineItem> lineItems = new List<OrderLineItem>();
            Order newOrder;

            foreach (PSOrderLineItem item in LineItems)
            {
                OrderLineItem lineItem = new OrderLineItem
                {
                    FriendlyName = item.FriendlyName,
                    LineItemNumber = item.LineItemNumber,
                    OfferId = item.OfferId,
                    ParentSubscriptionId = item.ParentSubscriptionId,
                    PartnerIdOnRecord = item.PartnerIdOnRecord,
                    Quantity = item.Quantity,
                    SubscriptionId = item.SubscriptionId
                };

                if (item.ProvisioningContext != null && item.ProvisioningContext.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kvp in item.ProvisioningContext.Cast<DictionaryEntry>().ToDictionary(entry => (string)entry.Key, kvp => (string)kvp.Value))
                    {
                        lineItem.ProvisioningContext.Add(kvp.Key, kvp.Value);
                    }
                }

                lineItems.Add(lineItem);
            }

            newOrder = new Order
            {
                BillingCycle = BillingCycle,
                LineItems = lineItems,
                ReferenceCustomerId = CustomerId
            };

            if (string.IsNullOrEmpty(OrderId))
            {
                newOrder = Partner.Customers[CustomerId].Orders.CreateAsync(newOrder).GetAwaiter().GetResult();
            }
            else
            {
                newOrder = Partner.Customers[CustomerId].Orders.ById(OrderId).PatchAsync(newOrder).GetAwaiter().GetResult();
            }

            WriteObject(new PSOrder(newOrder));
        }
    }
}