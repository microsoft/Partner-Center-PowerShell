// -----------------------------------------------------------------------
// <copyright file="CartError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Carts
{
    /// <summary>
    /// Represents an error associated to a cart line item.
    /// </summary>
    public class CartError
    {
        /// <summary>
        /// Gets or sets a cart error code.
        /// </summary>
        public CartErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets an error description.
        /// </summary>
        public string ErrorDescription { get; set; }
    }
}
