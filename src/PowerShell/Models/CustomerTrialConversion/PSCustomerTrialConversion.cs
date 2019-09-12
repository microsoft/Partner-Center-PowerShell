// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerTrialConversion
{
    using Extensions;
    using PartnerCenter.Models.Offers;
    using PartnerCenter.Models.Subscriptions;

    /// <summary>Holds customer trial conversion offers.</summary>
    public sealed class PSCustomerTrialConversion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerTrialConversion" /> class.
        /// </summary>
        public PSCustomerTrialConversion()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerTrialConversion" /> class.
        /// </summary>
        /// <param name="conversion">The base conversion for this instance.</param>
        public PSCustomerTrialConversion(Conversion conversion)
        {
            this.CopyFrom(conversion);
        }

        /// <summary>
        /// Gets or sets the offer list.
        /// </summary>
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the target offer.
        /// </summary>
        public string TargetOfferId { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or sets the quanity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a the billing cycle.
        /// </summary>
        public BillingCycleType BillingCycle { get; set; }
    }
}
