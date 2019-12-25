// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using Identity.Client;
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Provides an in-memory token cache for client applications.
    /// </summary>
    public sealed class InMemoryTokenCache : PartnerTokenCache
    {
        /// <summary>
        /// Identifier for the token cache.
        /// </summary>
        private const string cacheId = "CacheId";

        /// <summary>
        /// Provides a resource lock to ensure operations are performed in a thread-safe manner.
        /// </summary>
        private static readonly object resourceLock = new object();

        /// <summary>
        /// Provides a local in-memory cache for storing token information.
        /// </summary>
        private readonly IMemoryCache memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTokenCache" /> class.
        /// </summary>
        public InMemoryTokenCache()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        /// <summary>
        /// Gets the data from the cache.
        /// </summary>
        /// <param name="clientId">The client identifier used to request a token.</param>
        /// <returns>The data from the token cache.</returns>
        public override byte[] GetCacheData()
        {
            memoryCache.TryGetValue(cacheId, out byte[] value);

            return value;
        }

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public override void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (resourceLock)
            {
                memoryCache.Set(cacheId, args.TokenCache.SerializeMsalV3());
            }
        }

        /// <summary>
        /// Notification that is triggered before token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public override void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (resourceLock)
            {
                if (memoryCache.TryGetValue(cacheId, out byte[] value))
                {
                    args.TokenCache.DeserializeMsalV3(value);
                }
            }
        }
    }
}