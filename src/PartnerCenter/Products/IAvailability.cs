// -----------------------------------------------------------------------
// <copyright file="IAvailability.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on a single availability.
    /// </summary>
    public interface IAvailability : IPartnerComponent<Tuple<string, string, string, string>>, IEntityGetOperations<Availability>
    {
    }
}