// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.Customers;
    using Models.Subscriptions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscription", DefaultParameterSetName = "ByCustomer"), OutputType(typeof(PSSubscription))]
    public class GetPartnerCustomerSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer object used to scope the request.
        /// </summary>
        [Parameter(HelpMessage = "The customer object.", ParameterSetName = "ByCustomerObject", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSCustomer InputObject { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", ParameterSetName = "ByCustomer", Mandatory = true)]
        [Parameter(HelpMessage = "The identifier of the customer.", ParameterSetName = "ByOrder", Mandatory = true)]
        [Parameter(HelpMessage = "The identifier of the customer.", ParameterSetName = "ByPartner", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier corresponding to the order.", ParameterSetName = "ByCustomer", Mandatory = false)]
        [Parameter(HelpMessage = "The identifier corresponding to the order.", ParameterSetName = "ByCustomerObject", Mandatory = false)]
        [Parameter(HelpMessage = "The identifier corresponding to the order.", ParameterSetName = "ByOrder", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the MPN identifier.
        /// </summary>
        [Parameter(HelpMessage = "The Microsoft Parnter Network identifier that identifies the partner.", ParameterSetName = "ByCustomer", Mandatory = false)]
        [Parameter(HelpMessage = "The Microsoft Parnter Network identifier that identifies the partner.", ParameterSetName = "ByCustomerObject", Mandatory = false)]
        [Parameter(HelpMessage = "The Microsoft Parnter Network identifier that identifies the partner.", ParameterSetName = "ByPartner", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string MpnId { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "ByCustomer", Mandatory = false)]
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "ByCustomerObject", Mandatory = false)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            string customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;


            if (string.IsNullOrEmpty(SubscriptionId))
            {
                GetSubscriptions(customerId, MpnId, OrderId);
            }
            else
            {
                GetSubscription(customerId, SubscriptionId);
            }
        }

        private void GetSubscription(string customerId, string subscriptionId)
        {
            Subscription subscription;

            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));

            subscription = Partner.Customers[customerId].Subscriptions[subscriptionId].GetAsync().GetAwaiter().GetResult();
            WriteObject(new PSSubscription(subscription));
        }

        private void GetSubscriptions(string customerId, string mpnId = null, string orderId = null)
        {
            ResourceCollection<Subscription> subscriptions;

            if (!string.IsNullOrWhiteSpace(mpnId))
            {
                subscriptions = Partner.Customers[customerId].Subscriptions.ByPartner(mpnId).GetAsync().GetAwaiter().GetResult();
            }
            else if (!string.IsNullOrWhiteSpace(orderId))
            {
                subscriptions = Partner.Customers[customerId].Subscriptions.ByOrder(orderId).GetAsync().GetAwaiter().GetResult();
            }
            else
            {
                subscriptions = Partner.Customers[customerId].Subscriptions.GetAsync().GetAwaiter().GetResult();
            }

            WriteObject(subscriptions.Items.Select(s => new PSSubscription(s)), true);
        }
    }
}