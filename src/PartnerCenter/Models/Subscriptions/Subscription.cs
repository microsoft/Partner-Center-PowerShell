// -----------------------------------------------------------------------
// <copyright file="Subscription.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using System;
    using System.Collections.Generic;
    using Invoices;
    using Offers;

    /// <summary>
    /// The subscription resource represents the life cycle of a subscription and includes properties that define the states
    /// throughout the subscription life cycle.
    /// </summary>
    public sealed class Subscription : Contract
    {
        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        public IEnumerable<string> Actions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether automatic renew is enabled or not.
        /// </summary>
        public bool AutoRenewEnabled { get; set; }

        /// <summary>
        /// Gets or sets the billing cycle for the subscription.
        /// </summary>
        public BillingCycleType BillingCycle { get; set; }

        /// <summary>
        /// Gets or sets the billing type for the subscription.
        /// </summary>
        public BillingType BillingType { get; set; }

        /// <summary>
        /// Gets the type of contract.
        /// </summary>
        public override ContractType ContractType => ContractType.Subscription;

        /// <summary>
        /// Gets or sets the commitment end date for this subscription.
        /// </summary>
        public DateTime CommitmentEndDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the subscription was created.
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the effective start date for this subscription.
        /// </summary>
        public DateTime EffectiveStartDate { get; set; }

        /// <summary>
        /// Gets or sets the entitlment identifier for the subscription.
        /// </summary>
        public string EntiltmentId { get; set; }

        /// <summary>
        /// Gets or sets the subscription's friendly name.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription has purchasable add-ons.
        /// </summary>
        public bool HasPurchasableAddons { get; set; }

        /// <summary>
        /// Gets or sets the identifier for the subscription.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the subscription is a trial.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier used to purchase the subscription.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the offer name used to purchase the subscription.
        /// </summary>
        public string OfferName { get; set; }

        /// <summary>
        /// Gets or sets the parent subscription identifier.
        /// </summary>
        public string ParentSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the MPN identifier. This only applies to indirect partner scenarios.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the subscription.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscription.
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the links.
        /// </summary>
        public SubscriptionLinks Links { get; set; }

        /// <summary>
        /// Gets or sets the suspension reason for the subscription.
        /// </summary>
        public IEnumerable<string> SuspensionReasons { get; set; }

        /// <summary>
        /// Gets or sets the units definig the quantity for the subscription.
        /// </summary>
        public string UnitType { get; set; }
    }
}