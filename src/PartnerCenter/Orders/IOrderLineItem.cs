// -----------------------------------------------------------------------
// <copyright file="IOrderLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Orders
{
    using System;

    /// <summary>
    /// Represents the available order line item operations.
    /// </summary>
    public interface IOrderLineItem : IPartnerComponent<Tuple<string, string, int>>
    {
        /// <summary>
        /// Gets the available customer order line item activation link operations.
        /// </summary>
        IOrderLineItemActivationLink ActivationLink { get; }
    }
}