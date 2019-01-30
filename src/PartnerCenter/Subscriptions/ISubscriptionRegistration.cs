// -----------------------------------------------------------------------
// <copyright file="ISubscriptionRegistration.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Subscriptions
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the operations available on a customer's subscription registrations.
    /// </summary>
    public interface ISubscriptionRegistration : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Register a subscription to enable Azure Reserved instance purchase.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status.</returns>
        string Register(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Register a subscription to enable Azure Reserved instance purchase.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The location which indicates the URL of the API to query for status.</returns>
        Task<string> RegisterAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}