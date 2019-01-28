// -----------------------------------------------------------------------
// <copyright file="LegalBusinessProfile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Partners
{
    /// <summary>
    /// Represents a partner's billing profile.
    /// </summary>
    public sealed class BillingProfile : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingProfile" /> class.
        /// </summary>
        public BillingProfile()
        {
            Address = new Address();
            PrimaryContact = new Contact();
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