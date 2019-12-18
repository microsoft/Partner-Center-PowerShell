// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Identity.Client;
    using Identity.Client.Extensions.Msal;
    using Utilities;

    internal class PartnerTokenCache
    {
        private const string CacheFileName = "msal.cache";

        private static readonly string CacheFilePath =
            Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);

        private CrossPlatformLock cacheLock;

        private readonly string clientId;

        public PartnerTokenCache(string clientId)
        {
            this.clientId = clientId;
        }

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

        public static string GetTokenCacheKey(AuthenticationResult authResult, string applicationId)
        {
            return $"{authResult.Account.HomeAccountId.Identifier}-{authResult.Account.Environment}-RefreshToken-{applicationId}--";
        }
    }
}