// -----------------------------------------------------------------------
// <copyright file="IInvoiceDocuments.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    /// <summary>
    /// Defines the operations available on invoice documents.
    /// </summary>
    public interface IInvoiceDocuments : IPartnerComponent<string>
    {
        /// <summary>Gets an invoice statement operations.</summary>
        IInvoiceStatement Statement { get; }
    }
}