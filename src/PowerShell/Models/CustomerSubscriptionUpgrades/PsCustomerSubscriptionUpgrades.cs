// -----------------------------------------------------------------------
// <copyright file="PSCustomerSubscriptionUpgrades" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerSubscriptionUpgrades
{
    using Common;
    using Microsoft.Store.PartnerCenter.Models.Offers;
    using Microsoft.Store.PartnerCenter.Models.Subscriptions;

    /// <summary>Holds customer trial conversion offers.</summary>
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
        /// <param name="Upgrade">The base conversion for this instance.</param>
        
        public PSCustomerSubscriptionUpgrades(Upgrade upgrade)
        {
            this.CopyFrom(upgrade);
        }

        //
        // Summary:
        //     Gets or sets the offer to upgrade to.
        public Offer TargetOffer { get; set; }

        //
        // Summary:
        //     Gets or sets the type of upgrade.
        public UpgradeType UpgradeType { get; set; }

        //
        // Summary:
        //     Gets or sets a value indicating whether the upgrade can be performed.
        public bool IsEligible { get; set; }

        //
        // Summary:
        //     Gets or sets the quantity to be purchased. Defaults to the source subscription
        //     quantity.
        public int Quantity { get; set; }

    }

}
