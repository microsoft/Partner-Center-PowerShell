// -----------------------------------------------------------------------
// <copyright file="OrderError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Carts
{
    /// <summary>
    /// Represent an error with an order.
    /// </summary>
    public class OrderError : ResourceBase
    {
        /// <summary>
        /// Gets or sets the order group identifier with failure.
        /// </summary>
        public string OrderGroupId { get; set; }

        /// <summary>
        /// Gets or sets the error code associated with the issue.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the description of the issue.
        /// </summary>
        public string Description { get; set; }
    }
}
