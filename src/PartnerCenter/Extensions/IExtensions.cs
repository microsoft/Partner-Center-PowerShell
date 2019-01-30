// -----------------------------------------------------------------------
// <copyright file="IExtensions.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Extensions
{
    using Products;

    /// <summary>
    /// Holds operations that extend another set of operations.
    /// </summary>
    public interface IExtensions : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the product extension operations.
        /// </summary>
        IProductExtensions Product { get; }
    }
}