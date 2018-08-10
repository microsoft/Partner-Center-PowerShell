// -----------------------------------------------------------------------
// <copyright file="PSSubscribedSku.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses
{
    using System.Collections.Generic;
    using Common;
    using PartnerCenter.Models.Licenses;

    /// <summary>
    /// Represents a subscribed product owned by a tenant.
    /// </summary>
    public sealed class PSSubscribedSku
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscribedSku" /> class.
        /// </summary>
        public PSSubscribedSku()
        {
            ServicePlans = new List<ServicePlan>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSSubscribedSku" /> class.
        /// </summary>
        /// <param name="sku">The base sku for this instance.</param>
        public PSSubscribedSku(SubscribedSku sku)
        {
            ServicePlans = new List<ServicePlan>();
            this.CopyFrom(sku, CloneAdditionalOperations);
        }

        /// <summary>
        /// Addtional operations to be performed when cloning an instance of <see cref="SubscribedSku"/> to an instance of <see cref="PSSubscribedSku" />. 
        /// </summary>
        /// <param name="sku">The sku being cloned.</param>
        private void CloneAdditionalOperations(SubscribedSku sku)
        {
            ServicePlans.AddRange(sku.ServicePlans);
        }

        /// <summary>
        /// Gets or sets the number of units available for assignment. This is calculated as Total units - Consumed units.
        /// </summary>
        public int AvailableUnits { get; set; }

        /// <summary>
        /// Gets or sets the number of units active for assignment.
        /// </summary>
        public int ActiveUnits { get; set; }

        /// <summary>
        /// Gets or sets the number of consumed units.
        /// </summary>
        public int ConsumedUnits { get; set; }

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

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public ProductSku ProductSku { get; set; }

        /// <summary>
        /// Gets or sets the collection of service plans of a product.
        /// </summary>
        public List<ServicePlan> ServicePlans { get; }

        /// <summary>
        /// Gets or sets the SKU status of a product.
        /// </summary>
        public string CapabilityStatus { get; set; }
    }
}

