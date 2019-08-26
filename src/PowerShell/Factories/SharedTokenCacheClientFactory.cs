// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Security.Cryptography.X509Certificates;
    using Identity.Client;
    using Identity.Client.Extensions.Msal;
    using Utilities;

    public static class SharedTokenCacheClientFactory
    {
        private const string PowerShellClientId = "04b07795-8ddb-461a-bbee-02f9e1bf7b46";

        private const string CacheFileName = "msal.cache";

        private static readonly string CacheFilePath =
            Path.Combine(SharedUtilities.GetUserRootDirectory(), ".IdentityService", CacheFileName);

        private static ITokenCache tokenCache;

        private static MsalCacheHelper InitializeCacheHelper(string clientId)
        {
            StorageCreationPropertiesBuilder builder = new StorageCreationPropertiesBuilder(Path.GetFileName(CacheFilePath), Path.GetDirectoryName(CacheFilePath), clientId);

            builder = builder.WithMacKeyChain(serviceName: "Microsoft.Developer.IdentityService", accountName: "MSALCache");
            builder = builder.WithLinuxKeyring(
                schemaName: "msal.cache",
                collection: "default",
                secretLabel: "MSALCache",
                attribute1: new KeyValuePair<string, string>("MsalClientID", "Microsoft.Developer.IdentityService"),
                attribute2: new KeyValuePair<string, string>("MsalClientVersion", "1.0.0.0"));

            StorageCreationProperties storageCreationProperties = builder.Build();

            return MsalCacheHelper.CreateAsync(storageCreationProperties).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public static IConfidentialClientApplication CreateConfidentialClient(
            string authority = null,
            string clientId = null,
            string clientSecret = null,
            X509Certificate2 certificate = null,
            string redirectUri = null,
            string tenantId = null)
        {
            ConfidentialClientApplicationBuilder builder = ConfidentialClientApplicationBuilder.Create(clientId ?? PowerShellClientId);

            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(clientSecret))
            {
                builder = builder.WithClientSecret(clientSecret);
            }

            if (certificate != null)
            {
                builder = builder.WithCertificate(certificate);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder = builder.WithTenantId(tenantId);
            }

            IConfidentialClientApplication client = builder.Build();

            MsalCacheHelper cacheHelper = InitializeCacheHelper(clientId);
            cacheHelper.RegisterCache(client.UserTokenCache);

            return client;
        }

        public static IPublicClientApplication CreatePublicClient(
            string clientId = null,
            string tenantId = null,
            string authority = null,
            string redirectUri = null)
        {
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder.Create(clientId ?? PowerShellClientId);

            if (!string.IsNullOrEmpty(authority))
            {
                builder = builder.WithAuthority(authority);
            }

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder = builder.WithTenantId(tenantId);
            }

            IPublicClientApplication client = builder.Build();
            MsalCacheHelper cacheHelper = InitializeCacheHelper(clientId);

            cacheHelper.RegisterCache(client.UserTokenCache);

            return client;
        }

        public static ITokenCache GetTokenCache(string clientId)
        {
            if (tokenCache == null)
            {
                IPublicClientApplication client = CreatePublicClient(clientId);

                tokenCache = client.UserTokenCache;
            }

            return tokenCache;
        }
    }
}