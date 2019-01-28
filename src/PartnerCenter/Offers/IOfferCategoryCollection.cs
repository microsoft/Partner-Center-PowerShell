// -----------------------------------------------------------------------
// <copyright file="IOfferCategoryCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using GenericOperations;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Represents the behavior of offer categories available to partners.
    /// </summary>
    public interface IOfferCategoryCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<OfferCategory, ResourceCollection<OfferCategory>>
    {
    }
}