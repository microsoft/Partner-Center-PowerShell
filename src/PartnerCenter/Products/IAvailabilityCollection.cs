// -----------------------------------------------------------------------
// <copyright file="IAvailabilityCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on availabilities.
    /// </summary>
    public interface IAvailabilityCollection : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<Availability, ResourceCollection<Availability>>, IEntitySelector<IAvailability>
    {
        /// <summary>
        /// Gets the operations that can be applied on availabilities filtered by a specific target segment.
        /// </summary>
        /// <param name="targetSegment">The availability segment filter.</param>
        /// <returns>The availability collection operations by target segment.</returns>
        IAvailabilityCollectionByTargetSegment ByTargetSegment(string targetSegment);
    }
}