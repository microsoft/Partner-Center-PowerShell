// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Identity.Client;
    using Identity.Client.Extensions.Msal;
    using Extensions;

    /// <summary>
    /// Provides the ability to interact with the token cache file.
    /// </summary>
    internal class PartnerTokenCache
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
        /// The client identifier used to request a token.
        /// </summary>
        private readonly string clientId;

        /// <summary>
        /// The cross platform lock for the token cache.
        /// </summary>
        private CrossPlatformLock cacheLock;

        /// <summary>
        /// Initializes a new instance of the <see cref="PartnerTokenCache" /> class.
        /// </summary>
        /// <param name="clientId">The client identifier used to request a token.</param>
        public PartnerTokenCache(string clientId)
        {
            clientId.AssertNotEmpty(nameof(clientId));
            this.clientId = clientId;
        }

        /// <summary>
        /// Notification that is triggered after token acquisition.
        /// </summary>
        /// <param name="args">Arguments related to the cache item impacted</param>
        public void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            MsalCacheStorage cacheStorage = GetMsalCacheStorage(clientId);

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
        public void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            MsalCacheStorage cacheStorage = GetMsalCacheStorage(clientId);

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
        /// <param name="clientId">The client identifier used to request a token.</param>
        /// <returns>An aptly configured instance of the <see cref="MsalCacheStorage" /> class.</returns>
        public static MsalCacheStorage GetMsalCacheStorage(string clientId)
        {
            StorageCreationPropertiesBuilder builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), clientId);

            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));

            return new MsalCacheStorage(builder.Build());
        }

        /// <summary>
        /// Gets the key for the item in the token cache.
        /// </summary>
        /// <param name="authResult">The authentication result that represents the token retrieved.</param>
        /// <param name="clientId">The client identifier used to request a token.</param>
        /// <returns>The key for the item in the token cache.</returns>
        public static string GetTokenCacheKey(AuthenticationResult authResult, string clientId)
        {
            return $"{authResult.Account.HomeAccountId.Identifier}-{authResult.Account.Environment}-RefreshToken-{clientId}--";
        }
    }
}