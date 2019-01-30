// -----------------------------------------------------------------------
// <copyright file="ISubscriptionUsageRecordCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Usage
{
    using System;

    /// <summary>
    /// This interface defines behavior for a single subscription usage records.
    /// </summary>
    public interface ISubscriptionUsageRecordCollection : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets the subscription usage records grouped by days.
        /// </summary>
        ISubscriptionDailyUsageRecordCollection Daily { get; }

        /// <summary>
        /// Gets the subscription usage records grouped by resources.
        /// </summary>
        IResourceUsageRecordCollection Resources { get; }
    }
}