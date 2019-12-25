// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using Identity.Client;

    /// <summary>
    /// Implements the core functionality for a token cache.
    /// </summary>
    public abstract class PartnerTokenCache : IPartnerTokenCache
    {
        /// <summary>
        /// Gets or sets the client identifier used to request a token.
        /// </summary>
        public string ClientId { get; private set; }

        /// <summary>
        /// Gets the data from the cache.
        /// </summary>
        /// <returns>The data from the token cache.</returns>
        public virtual byte[] GetCacheData()
        {
            return null;
        }

        /// <summary>
        /// Gets the key for the item in the token cache.
        /// </summary>
        /// <param name="authResult">The authentication result that represents the token retrieved.</param>
        /// <returns>The key for the item in the token cache.</returns>
        public string GetCacheKey(AuthenticationResult authResult)
        {
            return $"{authResult.Account.HomeAccountId.Identifier}-{authResult.Account.Environment}-RefreshToken-{ClientId}--";
        }

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public virtual void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
        }

        /// <summary>
        /// Notification that is triggered before token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public virtual void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
        }

        /// <summary>
        /// Registers the token cache with client application.
        /// </summary>
        /// <param name="client">The client application to be used when registering the token cache.</param>
        public virtual void RegisterCache(IClientApplicationBase client)
        {
            ClientId = client.AppConfig.ClientId;

            client.UserTokenCache.SetAfterAccess(AfterAccessNotification);
            client.UserTokenCache.SetBeforeAccess(BeforeAccessNotification);
        }
    }
}