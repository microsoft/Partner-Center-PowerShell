// -----------------------------------------------------------------------
// <copyright file="IInvoiceLineItemCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models;
    using Models.Invoices;

    /// <summary>
    /// Represents the operations that can be done on partner's invoice line items.
    /// </summary>
    public interface IInvoiceLineItemCollection : IPartnerComponent<string>, IEntityCollectionRetrievalOperations<InvoiceLineItem, ResourceCollection<InvoiceLineItem>>
    {
    }
}