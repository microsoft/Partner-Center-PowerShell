// -----------------------------------------------------------------------
// <copyright file="IOfferAddOns.cs" company="Microsoft">
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
    /// Represents the behavior of an offer's add-ons.
    /// </summary>
    public interface IOfferAddOns : IPartnerComponent<Tuple<string, string>>, IEntityCollectionRetrievalOperations<Offer, ResourceCollection<Offer>>
    {
    }
}