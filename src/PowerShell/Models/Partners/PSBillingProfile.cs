// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Partners
{
    using Extensions;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Partners;

    /// <summary>
    /// Represents a partner's billing profile.
    /// </summary>
    public sealed class PSBillingProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSBillingProfile" /> class.
        /// </summary>
        public PSBillingProfile()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSBillingProfile" /> class.
        /// </summary>
        /// <param name="profile">The base billing profile for this instance.</param>
        public PSBillingProfile(BillingProfile profile)
        {
            this.CopyFrom(profile);
        }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the billing currency.
        /// </summary>
        public string BillingCurrency { get; set; }

        /// <summary>
        /// Gets or sets the billing day.
        /// </summary>
        public int? BillingDay { get; set; }

        /// <summary>
        /// Gets or sets the billing company name.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the billing primary contact.
        /// </summary>
        public Contact PrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the purchase order number.
        /// </summary>
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Gets or sets the tax identifier.
        /// </summary>
        public string TaxId { get; set; }
    }
}