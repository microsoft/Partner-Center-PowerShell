// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Subscriptions
{
    /// <summary>
    /// Provides information about activation status of a subscription.
    /// </summary>
    public sealed class PSSubscriptionActivationResult
    {
        /// <summary>
        /// Gets or sets activation status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets subscription identifier.
        /// </summary>
        public string SubscriptionId { get; set; }
    }
}