// -----------------------------------------------------------------------
// <copyright file="IReceipt.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    using System;

    /// <summary>
    /// Represents the available receipt operations.
    /// </summary>
    public interface IReceipt : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets the receipt documents behavior of the invoices.
        /// </summary>
        IReceiptDocuments Documents { get; }
    }
}