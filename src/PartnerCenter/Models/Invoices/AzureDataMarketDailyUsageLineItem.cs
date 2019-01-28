// -----------------------------------------------------------------------
// <copyright file="AzureDataMarketDailyUsageLineItem.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Invoices
{
    using System;

    /// <summary>
    /// Defines the properties of an Azure data market daily usage line item.
    /// </summary>
    public sealed class AzureDataMarketDailyUsageLineItem : BaseAzureDataMarketLineItem
    {

        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public override InvoiceLineItemType InvoiceLineItemType => InvoiceLineItemType.UsageLineItems;

        /// <summary>
        /// Gets or sets the metered service name.
        /// </summary>
        /// <remarks>
        /// Example: Storage.
        /// </remarks>
        public string MeteredServiceName { get; set; }

        /// <summary>
        /// Gets or sets the metered service type.
        /// </summary>
        /// <remarks>
        /// Example: External.
        /// </remarks>
        public string MeteredServiceType { get; set; }

        /// <summary>
        /// Gets or sets the customer assigned friendly name for the resource instance.
        /// </summary>
        public string ResourceFriendlyName { get; set; }

        /// <summary>
        /// Gets or sets the usage date the resource.
        /// </summary>
        public DateTime UsageDate { get; set; }
    }
}
