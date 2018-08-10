// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerSubscription.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Subscriptions;
    using PartnerCenter.PowerShell.Models.Customers;
    using PartnerCenter.PowerShell.Models.Subscriptions;

    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscription", DefaultParameterSetName = "Customer"), OutputType(typeof(PSSubscription))]
    public class GetPartnerCustomerSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the customer object used to scope the request.
        /// </summary>
        [Parameter(HelpMessage = "The customer object.", ParameterSetName = "CustomerObject", Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNull]
        public PSCustomer InputObject { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", ParameterSetName = "Customer", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The identifier of the subscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(SubscriptionId))
            {
                GetSubscriptions();
            }
            else
            {
                GetSubscription(SubscriptionId);
            }
        }

        /// <summary>
        /// Gets a specified subscription associated with the customer.
        /// </summary>
        /// <param name="subscriptionId">The identifier of the subscription.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="subscriptionId"/> is empty or null.
        /// </exception>
        public void GetSubscription(string subscriptionId)
        {
            Subscription subscription;
            string customerId;

            subscriptionId.AssertNotEmpty(nameof(subscriptionId));

            try
            {
                customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;
                subscription = Partner.Customers[customerId].Subscriptions[subscriptionId].Get();

                WriteObject(new PSSubscription(subscription));
            }
            finally
            {
                subscription = null;
            }
        }

        /// <summary>
        /// Gets a list of subscription of subscriptions associated with the customer.
        /// </summary>
        private void GetSubscriptions()
        {
            ResourceCollection<Subscription> subscriptions;
            string customerId;

            try
            {
                customerId = (InputObject == null) ? CustomerId : InputObject.CustomerId;
                subscriptions = Partner.Customers[customerId].Subscriptions.Get();

                WriteObject(subscriptions.Items.Select(s => new PSSubscription(s)), true);
            }
            finally
            {
                subscriptions = null;
            }
        }
    }
}