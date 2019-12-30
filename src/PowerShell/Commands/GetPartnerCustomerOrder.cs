// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Authentication;
    using Models.Orders;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// Get a customer, or a list of customers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerOrder")]
    [OutputType(typeof(PSOrder))]
    public class GetPartnerCustomerOrder : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the optional cilling cycle identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByBillingCycle", Mandatory = true, HelpMessage = "Indicates the type of billing cycle.")]
        [ValidateSet(nameof(BillingCycleType.Annual), nameof(BillingCycleType.Monthly), nameof(BillingCycleType.None), nameof(BillingCycleType.OneTime), nameof(BillingCycleType.Unknown))]
        public BillingCycleType? BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByOrderId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByBillingCycle", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether to include pricing details in the order information.
        /// </summary>
        [Parameter(HelpMessage = "A flag indicating whether to include pricing details in the order information.", Mandatory = false)]
        public SwitchParameter IncludePrice { get; set; }

        /// <summary>
        /// Gets or sets the optional order identifier.
        /// </summary>
        /// <remarks>
        /// If this parameter is not specified then a list of orders will be returned.
        /// When it is specified then the order associated with the identifier will be returned.
        /// </remarks>
        [Parameter(ParameterSetName = "ByOrderId", Mandatory = true, HelpMessage = "The identifier for the order.")]
        public string OrderId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                if (string.IsNullOrEmpty(OrderId))
                {
                    ResourceCollection<Order> orders;

                    if (BillingCycle.HasValue)
                    {
                        orders = await partner.Customers.ById(CustomerId).Orders.ByBillingCycleType(BillingCycle.Value).GetAsync(IncludePrice.ToBool(), CancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        orders = await partner.Customers.ById(CustomerId).Orders.GetAsync(IncludePrice.ToBool(), CancellationToken).ConfigureAwait(false);
                    }

                    WriteObject(orders.Items.Select(o => new PSOrder(o)), true);
                }
                else
                {
                    Order order = await partner.Customers.ById(CustomerId).Orders.ById(OrderId).GetAsync(IncludePrice.ToBool(), CancellationToken).ConfigureAwait(false);
                    WriteObject(new PSOrder(order));
                }

            }, true);
        }
    }
}