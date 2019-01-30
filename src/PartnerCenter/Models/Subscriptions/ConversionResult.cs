// -----------------------------------------------------------------------
// <copyright file="ConversionResult.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    /// <summary>
    /// Represents the result of performing a subscription conversion.
    /// </summary>
    public sealed class ConversionResult
    {
        /// <summary>
        /// Gets or sets the error encountered while attempting to perform the conversion, if applicable.
        /// </summary>
        public ConversionError Error { get; set; }

        /// <summary>
        /// Gets or sets the original offer identifier.
        /// </summary>
        public string OfferId { get; set; }
        /// <summary>
        /// Gets or sets the subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the target offer identifier.
        /// </summary>
        public string TargetOfferId { get; set; }
    }
}