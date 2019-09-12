// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Licenses
{
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Licenses;

    /// <summary>
    /// Represents a subscribed product owned by a tenant.
    /// </summary>
    public sealed class PSLicense
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicense" /> class.
        /// </summary>
        public PSLicense()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSLicense" /> class.
        /// </summary>
        /// <param name="license">The base license for this instance.</param>
        public PSLicense(License license)
        {
            LicensedProductSku = license.ProductSku.Id;
            Name = license.ProductSku.Name;
            LicenseGroupId = license.ProductSku.LicenseGroupId.ToString();

            this.CopyFrom(license);
        }

        /// <summary>
        /// Gets or sets the service plan collection. Service plans refer to services that
        /// user is assigned to use. For example , Delve is a service plan which a user is
        /// either assigned to use or can be assigned to use.
        /// </summary>
        public IEnumerable<ServicePlan> ServicePlans { get; set; }

        /// <summary>
        /// Gets or sets the product SKU which the license applies to.
        /// </summary>
        public ProductSku ProductSku { get; set; }

        /// <summary>
        /// Gets or sets the product SKU which the license applies to.
        /// </summary>
        public string LicensedProductSku { get; set; }

        /// <summary>
        /// Gets or sets the licensed product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the license group id.
        /// </summary>
        public string LicenseGroupId { get; set; }
    }
}