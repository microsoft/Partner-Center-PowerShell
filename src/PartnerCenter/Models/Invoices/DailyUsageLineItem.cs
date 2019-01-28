// -----------------------------------------------------------------------
// <copyright file="InvoiceLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using System;

    /// <summary>
    /// Defines the properties of a line item for usage based subscriptions.
    /// </summary>
    public sealed class DailyUsageLineItem : BaseUsageBasedLineItem
    {
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