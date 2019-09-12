// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Offers
{
    using Extensions;
    using PartnerCenter.Models.Offers;

    /// <summary>
    /// Represents an offer category.
    /// </summary>
    public class PSOfferCategory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSOfferCategory" /> class.
        /// </summary>
        public PSOfferCategory()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSOfferCategory" /> class.
        /// </summary>
        /// <param name="offer">The base offer for this instance.</param>
        public PSOfferCategory(OfferCategory offer)
        {
            this.CopyFrom(offer, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the country where the offer category applies.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        public string OfferCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the locale to which the offer category applies.
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category rank in the collection.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="OfferCategory" /> to an instance of <see cref="PSOfferCategory" />. 
        /// </summary>
        /// <param name="offerCategory">The offer category being cloned.</param>
        private void CloneAdditionalOperations(OfferCategory offerCategory) => OfferCategoryId = offerCategory.Id;
    }
}