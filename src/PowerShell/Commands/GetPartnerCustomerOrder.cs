﻿// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerOrder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Orders;
    using PartnerCenter.PowerShell.Models.Orders;

    /// <summary>
    /// Get a customer, or a list of customers, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerOrder"), OutputType(typeof(PSOrder))]
    public class GetPartnerCustomerOrder : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the required customer identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByOrderId", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [Parameter(ParameterSetName = "ByBillingCycle", Mandatory = true, HelpMessage = "The identifier for the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

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
        /// Gets or sets the optional cilling cycle identifier.
        /// </summary>
        [Parameter(ParameterSetName = "ByBillingCycle", Mandatory = true, HelpMessage = "Indicates the type of billing cycle.")]
        [ValidateSet(nameof(BillingCycleType.Annual), nameof(BillingCycleType.Monthly), nameof(BillingCycleType.None), nameof(BillingCycleType.OneTime), nameof(BillingCycleType.Unknown))]
        public BillingCycleType? BillingCycle { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(OrderId))
            {
                GetCustomerOrders(CustomerId, BillingCycle);
            }
            else
            {
                GetCustomerOrder(CustomerId, OrderId);
            }
        }

        /// <summary>
        /// Gets the specified customer order from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="orderId">Identifier of the order.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="orderId"/> is empty or null.
        /// </exception>
        private void GetCustomerOrder(string customerId, string orderId)
        {
            Order order;

            customerId.AssertNotEmpty(nameof(customerId));
            orderId.AssertNotEmpty(nameof(orderId));

            try
            {
                order = Partner.Customers.ById(customerId).Orders.ById(orderId).Get();

                WriteObject(new PSOrder(order));
            }
            finally
            {
                order = null;
            }
        }

        /// <summary>
        /// Gets a list of customer orders from Partner Center.
        /// </summary>
        /// <param name="customerId">Identifier of the customer.</param>
        /// <param name="billingCycle">BillingCycle identifier.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetCustomerOrders(string customerId, BillingCycleType? billingCycle)
        {
            IEnumerable<Order> orders;

            customerId.AssertNotEmpty(nameof(customerId));

            try
            {
                if (billingCycle.HasValue)
                {
                    orders = Partner.Customers.ById(customerId).Orders.ByBillingCycleType(billingCycle.Value).Get().Items;
                }
                else
                {
                    orders = Partner.Customers.ById(customerId).Orders.Get().Items;
                }

                WriteObject(orders.Select(o => new PSOrder(o)), true);
            }
            finally
            {
                orders = null;
            }
        }
    }
}