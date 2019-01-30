// -----------------------------------------------------------------------
// <copyright file="IOfferCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using GenericOperations;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Represents the operations that can be performed on offers.
    /// </summary>
    public interface IOfferCollection : IPartnerComponent<string>, IEntityCollectionRetrievalOperations<Offer, ResourceCollection<Offer>>, IEntitySelector<IOffer>
    {
        /// <summary>
        /// Retrieves the operations that can be applied on offers that belong to an offer category.
        /// </summary>
        /// <param name="categoryId">The offer category identifier.</param>
        /// <returns>The category offers operations.</returns>
        ICategoryOffersCollection ByCategory(string categoryId);
    }
}