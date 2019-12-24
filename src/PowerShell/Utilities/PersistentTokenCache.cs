﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Identity.Client;
    using Identity.Client.Extensions.Msal;

    /// <summary>
    /// Implements a token cache that leverages persistent storage.
    /// </summary>
    public sealed class PersistentTokenCache : PartnerTokenCache
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
        /// Gets the data from the cache.
        /// </summary>
        /// <returns>The data from the token cache.</returns>
        public override byte[] GetCacheData()
        {
            return GetMsalCacheStorage().ReadData();
        }

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public override void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            MsalCacheStorage cacheStorage = GetMsalCacheStorage();

            try
            {
                if (args.HasStateChanged)
                {
                    cacheStorage.WriteData(args.TokenCache.SerializeMsalV3());
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
            MsalCacheStorage cacheStorage = GetMsalCacheStorage();

            try
            {
                cacheLock = new CrossPlatformLock($"{CacheFilePath}.lockfile");

                cacheLock.CreateLockAsync().ConfigureAwait(false);
                args.TokenCache.DeserializeMsalV3(cacheStorage.ReadData());
            }
            catch (Exception)
            {
                cacheStorage.Clear();
                throw;
            }
        }


        /// <summary>
        /// Gets an aptly configured instance of the <see cref="MsalCacheStorage" /> class.
        /// </summary>
        /// <returns>An aptly configured instance of the <see cref="MsalCacheStorage" /> class.</returns>
        private MsalCacheStorage GetMsalCacheStorage()
        {
            StorageCreationPropertiesBuilder builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), ClientId);

            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));

            return new MsalCacheStorage(builder.Build());
        }
    }
}