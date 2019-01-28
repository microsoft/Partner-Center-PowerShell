// -----------------------------------------------------------------------
// <copyright file="ICustomerProductCollectionByTargetViewByTargetSegment.cs" company="Microsoft">
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
    /// Holds operations that can be performed on products in a given catalog view and that apply to a given customer, filtered by target segment.
    /// </summary>
    public interface ICustomerProductCollectionByTargetViewByTargetSegment : IPartnerComponent<Tuple<string, string, string>>, IEntireEntityCollectionRetrievalOperations<Product, ResourceCollection<Product>>
    {
    }
}