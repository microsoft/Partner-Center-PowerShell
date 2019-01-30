// -----------------------------------------------------------------------
// <copyright file="ICustomerProductCollectionByTargetView.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Customers.Products
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Products;

    /// <summary>
    /// Holds operations that can be performed on products in a given catalog view that apply to a given customer.
    /// </summary>
    public interface ICustomerProductCollectionByTargetView : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<Product, ResourceCollection<Product>>
    {
        /// <summary>
        /// Gets the operations that can be applied on products in a given catalog view and that apply to a given customer, filtered by target segment.
        /// </summary>
        /// <param name="targetSegment">The product segment filter.</param>
        /// <returns>The product collection operations by customer, by target view and by target segment.</returns>
        ICustomerProductCollectionByTargetViewByTargetSegment ByTargetSegment(string targetSegment);
    }
}