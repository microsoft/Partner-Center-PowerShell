// -----------------------------------------------------------------------
// <copyright file="OrderLineItemActivationLink.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Orders
{
    /// <summary>
    /// Represents the activation link for the order line item.
    /// </summary>
    public sealed class OrderLineItemActivationLink
    {
        /// <summary>
        /// Gets or sets the line item number.
        /// </summary>
        public int LineItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the activation link.
        /// </summary>
        public Link Link { get; set; }
    }
}