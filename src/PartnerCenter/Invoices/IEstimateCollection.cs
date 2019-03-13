// -----------------------------------------------------------------------
// <copyright file="IEstimateCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Invoices
{
    /// <summary>
    /// Represents the operations that can be done on the partner's estimate collection.
    /// </summary>
    public interface IEstimateCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Gets the estimate links of the recon line items.
        /// </summary>
        IEstimateLink Links { get; }
    }
}