// -----------------------------------------------------------------------
// <copyright file="PSSubscription.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using Common;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Invoices;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// The subscription resource represents the life cycle of a subscription and includes
    /// properties that define the states throughout the subscription life cycle.
    /// </summary>
    public sealed class PSSubscription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscription" /> class.
        /// </summary>
        public PSSubscription()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscription" /> class.
        /// </summary>
        /// <param name="subscription">The base subscription for this instance.</param>
        public PSSubscription(Subscription subscription)
        {
            this.CopyFrom(subscription, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        public IEnumerable<string> Actions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether automatic renew is enabled or not.
        /// </summary>
        public bool AutoRenewEnabled { get; set; }

        /// <summary>
        /// Gets or sets the billing cycle. 
        /// </summary>
        /// <remarks>
        /// Defines how often the partner is billed for this subscription.
        /// </remarks>
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the billing type.
        /// </summary>
        public BillingType BillingType { get; set; }

        /// <summary>
        /// Gets or sets the commitment end date for this subscription. For subscriptions which are not auto renewable, this represents a date far away in the future.
        /// </summary>
        public DateTime CommitmentEndDate { get; set; }

        /// <summary>
        /// Gets the type of contract.
        /// </summary>
        public ContractType ContractType { get; } = ContractType.Subscription;

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the effective start date for this subscription. It is used to back date a migrated subscription or to align it with another.
        /// </summary>
        public DateTime EffectiveStartDate { get; set; }

        /// <summary>
        /// Gets or sets the entitlement identifier.
        /// </summary>
        public string EntitlementId { get; set; }

        /// <summary>
        /// Gets or sets the friendly name for the subscription.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription has purchasable add-ons.
        /// </summary>
        public bool HasPurchasableAddons { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription is a trial.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the offer name.
        /// </summary>
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the  order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription identifier.
        /// </summary>
        public string ParentSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the MPN identifier. This only applies to indirect partner scenarios.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// For example, in case of seat based billing, this property is set to seat count.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the subscription status.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the suspension reason.
        /// </summary>
        public IEnumerable<string> SuspensionReasons { get; set; }

        /// <summary>
        /// Gets or sets the units defining Quantity for the subscription.
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Subscription "/> to an instance of <see cref="PSSubscription" />. 
        /// </summary>
        /// <param name="subscription">The subscription being cloned.</param>
        private void CloneAdditionalOperations(Subscription subscription)
        {
            SubscriptionId = subscription.Id;
        }
    }
}