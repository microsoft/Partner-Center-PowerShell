// -----------------------------------------------------------------------
// <copyright file="Contract.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models
{
    /// <summary>
    /// Base class for contracts.
    /// </summary>
    public abstract class Contract : ResourceBase
    {
        /// <summary>
        /// Gets the contract type.
        /// </summary>
        public abstract ContractType ContractType { get; }

        /// <summary>
        /// Gets or sets the  order identifier.
        /// </summary>
        public string OrderId { get; set; }
    }
}