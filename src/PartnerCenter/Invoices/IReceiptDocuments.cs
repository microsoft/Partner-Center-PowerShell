// -----------------------------------------------------------------------
// <copyright file="IReceiptDocuments.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;

    /// <summary>
    /// Represents the operations available on receipt documents.
    /// </summary>
    public interface IReceiptDocuments : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets the receipt statement operations.
        /// </summary>
        IReceiptStatement Statement { get; }
    }
}