// -----------------------------------------------------------------------
// <copyright file="ServicePlan.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Licenses
{
    using System.Collections.Generic;

    /// <summary>
    /// Model for subscribed products owned by a tenant.
    /// </summary>
    public sealed class SubscribedSku : ResourceBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscribedSku" /> class.
        /// </summary>
        public SubscribedSku()
        {
            ServicePlans = new List<ServicePlan>(); 
        }

        /// <summary>
        /// Gets or sets the number of units active for assignment.
        /// </summary>
        public int ActiveUnits { get; set; }

        /// <summary>
        /// Gets or sets the number of units available for assignment. This is calculated as Total units - Consumed units.
        /// </summary>
        public int AvailableUnits { get; set; }

        /// <summary>
        /// Gets or sets the SKU status of a product.
        /// </summary>
        public string CapabilityStatus { get; set; }

        /// <summary>
        /// Gets or sets the number of consumed units.
        /// </summary>
        public int ConsumedUnits { get; set; }

        /// <summary>Gets or sets the products.</summary>
        public ProductSku ProductSku { get; set; }

        /// <summary>
        /// Gets or sets the collection of service plans of a product.
        /// </summary>
        public List<ServicePlan> ServicePlans { get; }

        /// <summary>
        /// Gets or sets the number of suspended units.
        /// </summary>
        public int SuspendedUnits { get; set; }

        /// <summary>
        /// Gets or sets the total units, which is sum of active and warning units.
        /// </summary>
        public int TotalUnits { get; set; }

        /// <summary>
        /// Gets or sets the number of warning units.
        /// </summary>
        public int WarningUnits { get; set; }
    }
}