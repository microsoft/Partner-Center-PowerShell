// -----------------------------------------------------------------------
// <copyright file="IOffer.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Offers
{
    using System;
    using GenericOperations;
    using Models.Offers;

    /// <summary>
    /// Represents operations that can be performed on a single offer.
    /// </summary>
    public interface IOffer : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<Offer>
    {
        /// <summary>
        /// Gets the operations for the current offer's add-ons.
        /// </summary>
        IOfferAddOns AddOns { get; }
    }
}