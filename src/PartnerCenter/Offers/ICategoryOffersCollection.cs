// -----------------------------------------------------------------------
// <copyright file="ICategoryOffersCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Offers;

    /// <summary>
    /// Represents the operations that can be performed on offers that belong to an offer category.
    /// </summary>
    public interface ICategoryOffersCollection : IPartnerComponent<Tuple<string, string>>, IEntityCollectionRetrievalOperations<Offer, ResourceCollection<Offer>>
    {
    }
}