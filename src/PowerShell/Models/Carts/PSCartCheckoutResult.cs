// -----------------------------------------------------------------------
// <copyright file="PSCartCheckoutResult.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Carts
{
    using System.Collections.Generic;
    using Common;
    using PartnerCenter.Carts;
    using PartnerCenter.Models.Orders;

    /// <summary>
    /// Represents a result of a cart checkout.
    /// </summary>
    public sealed class PSCartCheckoutResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCartCheckoutResult" /> class.
        /// </summary>
        public PSCartCheckoutResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCartLineItem" /> class.
        /// </summary>
        /// <param name="checkoutResult">An instance of the <see cref="CartCheckoutResult" /> class that will serve as a base for this instance.</param>
        public PSCartCheckoutResult(CartCheckoutResult checkoutResult)
        {
            this.CopyFrom(checkoutResult);
        }

        /// <summary>
        /// Gets or sets a collection of order failure information.
        /// </summary>
        public IEnumerable<OrderError> OrderErrors { get; set; }

        /// <summary>
        /// Gets or sets the orders created.
        /// </summary>
        public IEnumerable<Order> Orders { get; set; }
    }
}