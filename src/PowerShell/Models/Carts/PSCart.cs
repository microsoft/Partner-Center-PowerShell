// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Carts
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Carts;

    /// <summary>
    /// This class represents a model of a cart object.
    /// </summary>
    public sealed class PSCart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCart" /> class.
        /// </summary>
        public PSCart()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCart" /> class.
        /// </summary>
        /// <param name="cart">The base cart for this instance.</param>
        public PSCart(Cart cart)
        {
            this.CopyFrom(cart, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the creation timestamp.
        /// </summary>
        public DateTime? CreationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the expiration timestamp.
        /// </summary>
        public DateTime ExpirationTimestamp { get; set; }

        /// <summary>
        /// Gets or sets a unique cart identifier.
        /// </summary>
        public string CartId { get; set; }

        /// <summary>
        /// Gets or sets the last modified timestamp.
        /// </summary>
        public DateTime? LastModifiedTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the last modified user or application.
        /// </summary>
        public string LastModifiedUser { get; set; }

        /// <summary>
        /// Gets or sets a collection of cart line items.
        /// </summary>
        public IEnumerable<CartLineItem> LineItems { get; set; }

        /// <summary>
        /// Gets or sets the cart status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Cart" /> to an instance of <see cref="PSCart" />. 
        /// </summary>
        /// <param name="cart">The cart being cloned.</param>
        private void CloneAdditionalOperations(Cart cart)
        {
            CartId = cart.Id;
        }
    }
}