// -----------------------------------------------------------------------
// <copyright file="ISku.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Products
{
    using System;
    using GenericOperations;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on a single SKU.
    /// </summary>
    public interface ISku : IPartnerComponent<Tuple<string, string, string>>, IEntityGetOperations<Sku>
    {
        /// <summary>
        /// Gets the operations for the current SKU's availabilities.
        /// </summary>
        IAvailabilityCollection Availabilities { get; }

        /// <summary>
        /// Gets the operations for the current SKU's download options.
        /// </summary>
        ISkuDownloadOptions DownloadOptions { get; }
    }
}