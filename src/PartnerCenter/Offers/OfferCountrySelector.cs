// -----------------------------------------------------------------------
// <copyright file="OfferCountrySelector.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using GenericOperations;

    /// <summary>
    /// An implementation that scopes offers and categories into a specific country.
    /// </summary>
    internal class OfferCountrySelector : BasePartnerComponent<string>, ICountrySelector<IOfferCollection>, ICountrySelector<IOfferCategoryCollection>
    {
        /// Initializes a new instance of the <see cref="OfferCountrySelector" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public OfferCountrySelector(IPartner rootPartnerOperations)
          : base(rootPartnerOperations)
        {
        }

        public IOfferCollection ByCountry(string country) => new OfferCollectionOperations(Partner, country);

        IOfferCategoryCollection ICountrySelector<IOfferCategoryCollection>.ByCountry(string country) => new OfferCategoryCollectionOperations(Partner, country);
    }
}