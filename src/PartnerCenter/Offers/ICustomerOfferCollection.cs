// -----------------------------------------------------------------------
// <copyright file="ICustomerOfferCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using GenericOperations;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Represents operations that can be performed on Offers available for the Customer.
    /// </summary>
    public interface ICustomerOfferCollection : IPartnerComponent<string>, IEntityCollectionRetrievalOperations<Offer, ResourceCollection<Offer>>
    {
    }
}