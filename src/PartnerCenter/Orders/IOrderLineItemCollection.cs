// -----------------------------------------------------------------------
// <copyright file="IOrderLineItemCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;
    using GenericOperations;

    /// <summary>
    /// Represents the available order line item operations.
    /// </summary>
    public interface IOrderLineItemCollection : IPartnerComponent<Tuple<string, string>>, IEntitySelector<int, IOrderLineItem>
    {
    }
}