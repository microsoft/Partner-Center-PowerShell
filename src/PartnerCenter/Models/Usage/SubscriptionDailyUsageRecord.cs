// -----------------------------------------------------------------------
// <copyright file="SubscriptionDailyUsageRecord.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Usage
{
    using System;

    /// <summary>
    /// Defines the daily usage record of a specific subscription.
    /// </summary>
    public sealed class SubscriptionDailyUsageRecord : UsageRecordBase
    {
        /// <summary>
        /// Gets or sets the usage date.
        /// </summary>
        public DateTimeOffset DateUsed { get; set; }
    }
}