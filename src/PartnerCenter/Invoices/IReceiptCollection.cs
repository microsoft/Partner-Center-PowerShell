// -----------------------------------------------------------------------
// <copyright file="IReceiptCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using GenericOperations;

    /// <summary>
    /// Represents the operations that can be done on receipt collection.
    /// </summary>
    public interface IReceiptCollection : IPartnerComponent<string>, IEntitySelector<IReceipt>
    {
    }
}