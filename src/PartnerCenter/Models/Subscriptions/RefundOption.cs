// -----------------------------------------------------------------------
// <copyright file="RefundOption.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using System;

    /// <summary>
    /// Represents the refund option for a subscription.
    /// </summary>
    public sealed class RefundOption
    {
        /// <summary>
        /// Gets or sets the timestamp when this policy expires if applicable, null otherwise.
        /// </summary>
        public DateTime? ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the type of refund ("Full, Partial")
        /// </summary>
        public string Type { get; set; }
    }
}
