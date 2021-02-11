// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using Identity.Client;
    using Identity.Client.Extensions.Msal;
    using Rest;

    /// <summary>
    /// Implements a token cache that leverages persistent storage.
    /// </summary>
    public class PersistentTokenCache : PartnerTokenCache, IDisposable
    {
        /// <summary>
        /// The file name for the token cache.
        /// </summary>
        private const string CacheFileName = "msal.cache";

        /// <summary>
        /// The file path for the token cache file.
        /// </summary>
        private static readonly string CacheFilePath =
            Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);

        /// <summary>
        /// The cross platform lock for the token cache.
        /// </summary>
        private CrossPlatformLock cacheLock;

        /// <summary>
        /// A flag indicating if the object has already been disposed.
        /// </summary>
        private bool disposed = false;

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
                cacheLock?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Gets the data from the cache.
        /// </summary>
        /// <returns>The data from the token cache.</returns>
        public override byte[] GetCacheData()
        {
            return GetMsalCacheStorage().LoadUnencryptedTokenCache();
        }

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public override void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            MsalCacheHelper cacheStorage = GetMsalCacheStorage();

            args.AssertNotNull(nameof(args));

            try
            {
                if (args.HasStateChanged)
                {
                    cacheStorage.SaveUnencryptedTokenCache(args.TokenCache.SerializeMsalV3());
                }
            }
            catch (Exception)
            {
                cacheStorage.Clear();
                throw;
            }
            finally
            {
                CrossPlatformLock localDispose = cacheLock;
                cacheLock = null;
                localDispose?.Dispose();
            }
        }

        /// <summary>
        /// Notification that is triggered before token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public override void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            MsalCacheHelper cacheStorage = GetMsalCacheStorage();

            args.AssertNotNull(nameof(args));

            try
            {
                cacheLock = new CrossPlatformLock($"{CacheFilePath}.lockfile");

                cacheLock.CreateLockAsync().ConfigureAwait(false);
                args.TokenCache.DeserializeMsalV3(cacheStorage.LoadUnencryptedTokenCache());
            }
            catch (Exception)
            {
                cacheStorage.Clear();
                throw;
            }
        }

        /// <summary>
        /// Registers the token cache with client application.
        /// </summary>
        /// <param name="client">The client application to be used when registering the token cache.</param>
        public override void RegisterCache(IClientApplicationBase client)
        {
            ServiceClientTracing.Information("Registering the persistent token cache.");

            base.RegisterCache(client);
        }

        /// <summary>
        /// Gets an aptly configured instance of the <see cref="MsalCacheStorage" /> class.
        /// </summary>
        /// <returns>An aptly configured instance of the <see cref="MsalCacheStorage" /> class.</returns>
        private MsalCacheHelper GetMsalCacheStorage()
        {
            StorageCreationPropertiesBuilder builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), ClientId);

            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));

            return MsalCacheHelper.CreateAsync(builder.Build(), new TraceSource("Partner Center PowerShell")).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}