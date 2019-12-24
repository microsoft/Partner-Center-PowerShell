// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using Identity.Client;

    /// <summary>
    /// Represents the core functionality for a token cache.
    /// </summary>
    public interface IPartnerTokenCache
    {
        /// <summary>
        /// Gets the client identifier used to request a token.
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Gets the data from the cache.
        /// </summary>
        /// <returns>The data from the token cache.</returns>
        byte[] GetCacheData();

        /// <summary>
        /// Gets the key for the item in the token cache.
        /// </summary>
        /// <param name="authResult">The authentication result that represents the token retrieved.</param>
        /// <returns>The key for the item in the token cache.</returns>
        string GetCacheKey(AuthenticationResult authResult);

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        void AfterAccessNotification(TokenCacheNotificationArgs args);

        /// <summary>
        /// Notification that is triggered before token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        void BeforeAccessNotification(TokenCacheNotificationArgs args);

        /// <summary>
        /// Registers the token cache with client application.
        /// </summary>
        /// <param name="client">The client application to be used when registering the token cache.</param
        void RegisterCache(IClientApplicationBase client);
    }
}