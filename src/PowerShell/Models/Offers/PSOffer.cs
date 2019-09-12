// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Offers
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Invoices;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Represents a form of product availability to customer.
    /// </summary>
    public sealed class PSOffer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOffer" /> class.
        /// </summary>
        public PSOffer()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOffer" /> class.
        /// </summary>
        /// <param name="offer">The base offer for this instance.</param>
        public PSOffer(Offer offer)
        {
            this.CopyFrom(offer, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets how billing is handled for the item purchase.
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
        /// Gets or sets the description of the offer.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the offer is an add-on.
        /// </summary>
        public bool IsAddOn { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the offer is auto renewable.
        /// </summary>
        public bool IsAutoRenewable { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the offer is available for purchase.
        /// </summary>
        public bool IsAvailableForPurchase { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not the offer is a trial.
        /// </summary>
        public bool IsTrial { get; set; }

        /// <summary>
        /// Gets or sets the locale where the offer applies.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the minimum quantity available.
        /// </summary>
        public int MinimumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the maximum quantity available.
        /// </summary>
        public int MaximumQuantity { get; set; }

        /// <summary>
        /// Gets or sets the name of the offer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the idntifier of the offer.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets prerequisites for the offer.
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
        /// Gets or sets the identifier for the sales group.
        /// </summary>
        public string SalesGroupId { get; set; }

        /// <summary>
        /// Gets or sets the supported billing cycles for the offer.
        /// </summary>
        public IEnumerable<BillingCycleType> SupportedBillingCycles { get; set; }

        /// <summary>
        /// Gets or sets the list of offers that this offer can be upgraded to. 
        /// </summary>
        public IEnumerable<string> UpgradeTargetOffers { get; set; }

        /// <summary>
        /// Gets or sets the unit type.
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Offer" /> to an instance of <see cref="PSOffer" />. 
        /// </summary>
        /// <param name="offer">The offer being cloned.</param>
        private void CloneAdditionalOperations(Offer offer) => OfferId = offer.Id;
    }
}