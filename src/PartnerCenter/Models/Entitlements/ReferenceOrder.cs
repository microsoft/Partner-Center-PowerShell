// -----------------------------------------------------------------------
// <copyright file="ReferenceOrder.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Entitlements
{
    /// <summary>
    /// Class that represents an order linked to the entitlement.
    /// </summary>
    public class ReferenceOrder : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets order identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets order line item identifier.
        /// </summary>
        public string LineItemId { get; set; }
    }
}