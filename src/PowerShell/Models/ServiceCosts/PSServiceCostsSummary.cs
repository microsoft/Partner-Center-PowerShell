// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.ServiceCosts
{
    using System;
    using Extensions;
    using PartnerCenter.Models.ServiceCosts;

    /// <summary>
    /// Represents a service costs summary for a customer.
    /// </summary>
    public sealed class PSServiceCostsSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSServiceCostsSummary" /> class.
        /// </summary>
        public PSServiceCostsSummary()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSServiceCostsSummary" /> class.
        /// </summary>
        /// <param name="summary">The base summary for this instance.</param>
        public PSServiceCostsSummary(ServiceCostsSummary summary)
        {
            this.CopyFrom(summary);
        }

        /// <summary>
        /// Gets or sets the total = pretax + tax for the customer.
        /// </summary>
        public decimal AfterTaxTotal { get; set; }

        /// <summary>
        /// Gets or sets the end of the billing period.
        /// </summary>
        public DateTime BillingEndDate { get; set; }

        /// <summary>
        /// Gets or sets the start of the billing period.
        /// </summary>
        public DateTime BillingStartDate { get; set; }

        /// <summary>
        /// Gets or sets the currency code for the costs.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the currency symbol for the costs.
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the pre tax total of costs of the customer.
        /// </summary>
        public decimal PretaxTotal { get; set; }

        /// <summary>Gets or sets the total tax for the customer.</summary>
        public decimal Tax { get; set; }
    }
}