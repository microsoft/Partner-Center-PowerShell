// -----------------------------------------------------------------------
// <copyright file="IInvoiceSummaryCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;
    using Models;
    using Models.Invoices;

    /// <summary>
    /// Represents all the operations that can be done on invoice summary collection.
    /// </summary>
    public interface IInvoiceSummaryCollection : IPartnerComponent<string>, IEntityGetOperations<ResourceCollection<InvoiceSummary>>
    {
    }
}