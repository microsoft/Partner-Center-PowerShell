// -----------------------------------------------------------------------
// <copyright file="SetPartnerCustomerSubscription.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Models.Customers;
    using Models.Subscriptions;
    using PartnerCenter.Models.Subscriptions;
    using Properties;

    [Cmdlet(VerbsCommon.Set, "PartnerCustomerSubscription", SupportsShouldProcess = true), OutputType(typeof(PSSubscription))]
    public class SetPartnerCustomerSubscription : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets a flag indiciating whether or not the subscription will auto renew.
        /// </summary>
        [Parameter(HelpMessage = "A flag indiciating whether or not the subscription will auto renew.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "A flag indiciating whether or not the subscription will auto renew.", ParameterSetName = "CustomerObject", Mandatory = false)]
        public bool? AutoRenew { get; set; }

        /// <summary>
        /// Gets or sets the customer object used to scope the request.
        /// </summary>
        [Parameter(HelpMessage = "The customer object used to scope the request.", ParameterSetName = "CustomerObject", Mandatory = true)]
        public PSCustomer InputObject { get; set; }

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
        [Parameter(HelpMessage = "The friendly name of the sbuscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [Parameter(HelpMessage = "The quantity of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The quantity of the sbuscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The status of the subscription.", ParameterSetName = "Customer", Mandatory = false)]
        [Parameter(HelpMessage = "The status of the subscription.", ParameterSetName = "CustomerObject", Mandatory = false)]
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

            subscription = Partner.Customers[customerId].Subscriptions[SubscriptionId].Get();

            if (AutoRenew.HasValue)
            {
                subscription.AutoRenewEnabled = AutoRenew.Value;
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

            subscription = Partner.Customers[customerId].Subscriptions[SubscriptionId].Patch(subscription);

            WriteObject(new PSSubscription(subscription));
        }
    }
}