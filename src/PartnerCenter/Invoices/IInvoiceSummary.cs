// -----------------------------------------------------------------------
// <copyright file="IInvoiceSummary.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models.Invoices;

    /// <summary>
    /// Represents all the operations that can be done on an invoice summary.
    /// </summary>
    public interface IInvoiceSummary : IPartnerComponent<string>, IEntityGetOperations<InvoiceSummary>
    {
    }
}