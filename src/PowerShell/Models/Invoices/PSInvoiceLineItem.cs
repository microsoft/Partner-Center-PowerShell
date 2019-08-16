// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Invoices
{
    using PartnerCenter.Models.Invoices;

    /// <summary>
    /// Represents a line item on an invoice.
    /// </summary>
    public abstract class PSInvoiceLineItem
    {
        /// <summary>
        /// Gets the type of invoice line item.
        /// </summary>
        public abstract InvoiceLineItemType InvoiceLineItemType { get; }

        /// <summary>
        /// Gets the billing provider.
        /// </summary>
        public abstract BillingProvider BillingProvider { get; }
    }
}