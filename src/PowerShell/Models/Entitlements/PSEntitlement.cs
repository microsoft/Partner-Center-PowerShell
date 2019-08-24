// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Entitlements
{
    using System;
    using System.Collections.Generic;
    using Extensions;
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
        /// Gets or sets entitlement type.
        /// </summary>
        public string EntitlementType { get; set; }

        /// <summary>
        /// Gets or sets the entitlement expiry date.
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the fulfillment state for the current entitlement.
        /// </summary>
        public string FulfillmentState { get; set; }

        /// <summary>
        /// Gets or sets included entitlements.
        /// </summary>
        public IEnumerable<Entitlement> IncludedEntitlements { get; set; }

        /// <summary>
        /// Gets or sets product identifier.
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
        /// Gets or sets SKU identifier.
        /// </summary>
        public string SkuId { get; set; }
    }
}