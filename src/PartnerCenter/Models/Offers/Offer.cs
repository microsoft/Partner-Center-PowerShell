// -----------------------------------------------------------------------
// <copyright file="Offer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Offers
{
    using System;
    using System.Collections.Generic;
    using Invoices;

    /// <summary>
    /// Represents a form of product availability to customer.
    /// </summary>
    public sealed class Offer : ResourceBaseWithLinks<OfferLinks>
    {
        /// <summary>
        /// Gets or sets how billing is done for the line item purchase.
        /// </summary>
        public BillingType Billing { get; set; }

        /// <summary>
        /// Gets or sets the offer category.
        /// </summary>
        public OfferCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the country where the offer applies.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the offer description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this offer has any add-ons
        /// </summary>
        public bool HasAddOns { get; set; }

        /// <summary>
        /// Gets or sets the offer identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this offer is an add-on.
        /// </summary>
        public bool IsAddOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the offer is automatically renewable.
        /// </summary>
        public bool IsAutoRenewable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is available for purchase.
        /// </summary>
        public bool IsAvailableForPurchase { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether this is a trial offer.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets the amount of subscriptions that can be purchased of this offer based on the limitUnitOfMeasure
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets the value used to indicate the type of the purchase limitation
        /// </summary>
        public string LimitUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets the locale to which the offer applies.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity available.
        /// </summary>
        public int MaximumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity available.
        /// </summary>
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the offer name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the prerequisite offers.
        /// </summary>
        public IEnumerable<string> PrerequisiteOffers { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the category rank in the offer collection.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets qualifications required by the customer for the partner to purchase it for the customer.
        /// </summary>
        public IEnumerable<string> ReselleeQualifications { get; set; }

        /// <summary>
        /// Gets or sets qualifications required by the Partner in order to purchase the offer for a customer.
        /// </summary>
        public IEnumerable<string> ResellerQualifications { get; set; }

        /// <summary>
        /// Gets or sets the sale group id for the offer.
        /// When placing an order, one has to ensure that the order contains items of the sales group, if not split them.
        /// </summary>
        /// <value>The sales group identifier.</value>
        public string SalesGroupId { get; set; }

        /// <summary>
        /// Gets or sets the supported billing cycles for the offer.
        /// </summary>
        /// <value>A collection of billing cycles supported for this offer.</value>
        public IEnumerable<BillingCycleType> SupportedBillingCycles { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit.
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Gets or sets the list of offers that this offer can be upgraded to.
        /// </summary>
        public IEnumerable<string> UpgradeTargetOffers { get; set; }

        /// <summary>
        /// Gets or sets the offer URI.
        /// </summary>
        public Uri Uri { get; set; }
    }
}