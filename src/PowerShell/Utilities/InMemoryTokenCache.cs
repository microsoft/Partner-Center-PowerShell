// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using Identity.Client;
    using Microsoft.Extensions.Caching.Memory;
    using Rest;

    /// <summary>
    /// Provides an in-memory token cache for client applications.
    /// </summary>
    public class InMemoryTokenCache : PartnerTokenCache, IDisposable
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
        /// A flag indicating if the object has already been disposed.
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryTokenCache" /> class.
        /// </summary>
        public InMemoryTokenCache()
        {
            memoryCache = new MemoryCache(new MemoryCacheOptions());
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                memoryCache?.Dispose();
            }

            disposed = true;
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
            args.AssertNotNull(nameof(args));

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
            args.AssertNotNull(nameof(args));

            lock (resourceLock)
            {
                if (memoryCache.TryGetValue(cacheId, out byte[] value))
                {
                    args.TokenCache.DeserializeMsalV3(value);
                }
            }
        }

        /// <summary>
        /// Registers the token cache with client application.
        /// </summary>
        /// <param name="client">The client application to be used when registering the token cache.</param>
        public override void RegisterCache(IClientApplicationBase client)
        {
            ServiceClientTracing.Information("Registering the in-memory token cache.");

            base.RegisterCache(client);
        }
    }
}