// -----------------------------------------------------------------------
// <copyright file="IReconLineItemCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models;
    using Models.Invoices;

    /// <summary>
    /// Represents the operations that can be done on partner's recon line items.
    /// </summary>
    public interface IReconLineItemCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<InvoiceLineItem, SeekBasedResourceCollection<InvoiceLineItem>>
    {
    }
}