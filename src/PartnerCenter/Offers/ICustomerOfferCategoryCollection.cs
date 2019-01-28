// -----------------------------------------------------------------------
// <copyright file="ICustomerOfferCategoryCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using GenericOperations;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Represents operations that can be performed on OfferCategories available for the Customer.
    /// </summary>
    public interface ICustomerOfferCategoryCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<OfferCategory, ResourceCollection<OfferCategory>>
    {
    }
}