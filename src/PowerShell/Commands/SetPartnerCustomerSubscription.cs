// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Customers;
    using Models.Subscriptions;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Orders;
    using PartnerCenter.Models.Subscriptions;
    using Properties;

    [Cmdlet(VerbsCommon.Set, "PartnerCustomerSubscription", SupportsShouldProcess = true), OutputType(typeof(PSSubscription))]
    public class SetPartnerCustomerSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer object used to scope the request.
        /// </summary>
        [Parameter(HelpMessage = "The customer object used to scope the request.", ParameterSetName = "CustomerObject", Mandatory = true)]
        public PSCustomer InputObject { get; set; }

        /// <summary>
        /// Gets or sets the billing cycle for the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The billing cycle for the subscription.", Mandatory = false)]
        [ValidateSet(nameof(BillingCycleType.Annual), nameof(BillingCycleType.Monthly))]
        public BillingCycleType? BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", ParameterSetName = "Customer", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The friendly name of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The friendly name of the subscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [Parameter(HelpMessage = "The quantity of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The quantity of the subscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The status of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The status of the subscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        [ValidateSet(nameof(SubscriptionStatus.Active), nameof(SubscriptionStatus.Deleted), nameof(SubscriptionStatus.Suspended))]
        public SubscriptionStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "Customer", Mandatory = true)]
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "CustomerObject", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Subscription subscription;
            string customerId;

            customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;

            if (!ShouldProcess(
                string.Format(
                    CultureInfo.CurrentCulture, Resources.SetPartnerCustomerSubscriptionWhatIf, SubscriptionId,
                    customerId)))
            {
                return;
            }

            subscription = Partner.Customers[customerId].Subscriptions[SubscriptionId].GetAsync().GetAwaiter().GetResult();


            if (BillingCycle.HasValue)
            {
                Partner.Customers[customerId].Orders[subscription.OrderId].PatchAsync(new Order
                {
                    BillingCycle = BillingCycle.Value,
                    LineItems = new List<OrderLineItem>
                    {
                       new OrderLineItem
                       {
                           LineItemNumber = 0,
                           OfferId = subscription.OfferId,
                           ParentSubscriptionId = subscription.ParentSubscriptionId,
                           SubscriptionId = subscription.Id,
                           Quantity = subscription.Quantity
                       }
                    },
                    ReferenceCustomerId = customerId
                }).GetAwaiter().GetResult();

                subscription.BillingCycle = BillingCycle.Value;
            }

            if (!string.IsNullOrEmpty(FriendlyName))
            {
                subscription.FriendlyName = FriendlyName;
            }

            if (Quantity.HasValue)
            {
                subscription.Quantity = Quantity.Value;
            }

            if (Status.HasValue)
            {
                subscription.Status = Status.Value;
            }

            subscription = Partner.Customers[customerId].Subscriptions[SubscriptionId].PatchAsync(subscription).GetAwaiter().GetResult();

            WriteObject(new PSSubscription(subscription));
        }
    }
}