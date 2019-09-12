// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using System;
    using Extensions;
    using PartnerCenter.Models.Invoices;

    public sealed class PSDailyUsageLineItem : PSBaseUsageBasedLineItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSDailyUsageLineItem" /> class.
        /// </summary>
        public PSDailyUsageLineItem()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSDailyUsageLineItem" /> class.
        /// </summary>
        /// <param name="lineItem">The base line item for this instance.</param>
        public PSDailyUsageLineItem(DailyUsageLineItem lineItem)
        {
            this.CopyFrom(lineItem);
        }

        /// <summary>
        /// Gets or sets the customer billable account.
        /// </summary>
        public string CustomerBillableAccount { get; set; }

        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public override InvoiceLineItemType InvoiceLineItemType => InvoiceLineItemType.UsageLineItems;

        /// <summary>
        /// Gets or sets the metered region.
        /// </summary>
        /// <remarks>
        /// Example: West US.
        /// </remarks>
        public string MeteredRegion { get; set; }

        /// <summary>
        /// Gets or sets the metered service name. 
        /// </summary>
        /// <remarks>
        /// Example: Storage
        /// </remarks>
        public string MeteredService { get; set; }

        /// <summary>
        /// Gets or sets the metered service type. Example: External.
        /// </summary>
        public string MeteredServiceType { get; set; }

        /// <summary>
        /// Gets or sets the project or instance name.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Gets or sets the additional service information.
        /// </summary>
        public string ServiceInfo { get; set; }

        /// <summary>
        /// Gets or sets the usage date of the resource.
        /// </summary>
        public DateTime UsageDate { get; set; }
    }
}