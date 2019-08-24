// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerSubscriptionUpgrades
{
    using Extensions;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>
    /// Holds customer trial conversion offers.
    /// </summary>
    public sealed class PSCustomerSubscriptionUpgrades
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerSubscriptionUpgrades" /> class.
        /// </summary>
        public PSCustomerSubscriptionUpgrades()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerSubscriptionUpgrades" /> class.
        /// </summary>
        /// <param name="upgrade">The base conversion for this instance.</param>

        public PSCustomerSubscriptionUpgrades(Upgrade upgrade)
        {
            this.CopyFrom(upgrade);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the upgrade can be performed.
        /// </summary>
        public bool IsEligible { get; set; }

        /// <summary>
        /// Gets or sets the quantity to be purchased. Defaults to the source subscription quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the target offer.
        /// </summary>
        public Offer TargetOffer { get; set; }

        /// <summary>
        /// Gets or sets the type of upgrade.
        /// </summary>
        public UpgradeType UpgradeType { get; set; }
    }
}