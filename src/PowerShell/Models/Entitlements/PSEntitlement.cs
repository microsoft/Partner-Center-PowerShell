// -----------------------------------------------------------------------
// <copyright file="PSEntitlement.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Entitlements
{
    using System.Collections.Generic;
    using Common;
    using PartnerCenter.Models.Entitlements;

    /// <summary>
    /// This resource represents the products to which the customer has right to use because of partner purchase on items from the catalog.
    /// </summary>
    public sealed class PSEntitlement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSEntitlement" /> class.
        /// </summary>
        public PSEntitlement()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSEntitlement" /> class.
        /// </summary>
        /// <param name="entitlement">The base customer for this instance.</param>
        public PSEntitlement(Entitlement entitlement)
        {
            this.CopyFrom(entitlement);
        }

        /// <summary>
        /// Gets or sets collection of entitled artifacts.
        /// </summary>
        public IEnumerable<Artifact> EntitledArtifacts { get; set; }

        /// <summary>
        ///  Gets or sets the entitlement type.
        /// </summary>
        public string EntitlementType { get; set; }

        /// <summary>
        /// Gets or sets included entitlements.
        /// </summary>
        public IEnumerable<Entitlement> IncludedEntitlements { get; set; }

        /// <summary>
        /// Gets or sets identifier of the product.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the quantity details (quantity - state).
        /// </summary>
        public IEnumerable<QuantityDetail> QuantityDetails { get; set; }

        /// <summary>
        /// Gets or sets reference order related to the entitlement.
        /// </summary>
        public ReferenceOrder ReferenceOrder { get; set; }

        /// <summary>
        /// Gets or sets identifier of the SKU.
        /// </summary>
        public string SkuId { get; set; }
    }
}