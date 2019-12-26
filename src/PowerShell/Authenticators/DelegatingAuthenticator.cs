// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;
    using Utilities;

    /// <summary>
    /// Provides a chain of responsibility pattern for authenticators.
    /// </summary>
    internal abstract class DelegatingAuthenticator : IAuthenticator
    {
        /// <summary>
        /// Gets or sets the next authenticator in the chain.
        /// </summary>
        public IAuthenticator Next { get; set; }

        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public abstract Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public abstract bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Gets an aptly configured client.
        /// </summary>
        /// <param name="account">The account information to be used when generating the client.</param>
        /// <param name="environment">The environment where the client is connecting.</param>
        /// <param name="redirectUri">The redirect URI for the client.</param>
        /// <returns>An aptly configured client.</returns>
        public IClientApplicationBase GetClient(PartnerAccount account, PartnerEnvironment environment, string redirectUri = null)
        {
            IClientApplicationBase app;

            if (account.IsPropertySet(PartnerAccountPropertyType.CertificateThumbprint) || account.IsPropertySet(PartnerAccountPropertyType.ServicePrincipalSecret))
            {
                app = CreateConfidentialClient(
                    GetAzureCloudInstance(environment),
                    account.GetProperty(PartnerAccountPropertyType.ApplicationId),
                    account.GetProperty(PartnerAccountPropertyType.ServicePrincipalSecret),
                    GetCertificate(account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint)),
                    redirectUri,
                    account.Tenant);
            }
            else
            {
                app = CreatePublicClient(
                    GetAzureCloudInstance(environment),
                    account.GetProperty(PartnerAccountPropertyType.ApplicationId),
                    redirectUri,
                    account.Tenant);
            }

            return app;
        }

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns><c>true</c> if the request can be authenticated; otherwise <c>false</c>.</returns>
        public async Task<AuthenticationResult> TryAuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default)
        {
            if (CanAuthenticate(parameters))
            {
                return await AuthenticateAsync(parameters, cancellationToken).ConfigureAwait(false);
            }

            if (Next != null)
            {
                return await Next.TryAuthenticateAsync(parameters, cancellationToken).ConfigureAwait(false);
            }

            return null;
        }

        /// <summary>
        /// Creates a confidential client used for generating tokens.
        /// </summary>
        /// <param name="cloudInstance">The cloud instance used for authentication.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="certificate">Certificate used by the client requesting the token.</param>
        /// <param name="clientSecret">Secret of the client requesting the token.</param>
        /// <param name="redirectUri">The redirect URI for the client.</param>
        /// <param name="tenantId">Identifier of the tenant requesting the token.</param>
        /// <returns>An aptly configured confidential client.</returns>
        private static IConfidentialClientApplication CreateConfidentialClient(
            AzureCloudInstance cloudInstance,
            string clientId = null,
            string clientSecret = null,
            X509Certificate2 certificate = null,
            string redirectUri = null,
            string tenantId = null)
        {
            ConfidentialClientApplicationBuilder builder = ConfidentialClientApplicationBuilder.Create(clientId);

            builder = builder.WithAuthority(cloudInstance, tenantId);

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

            IConfidentialClientApplication client = builder.WithLogging((level, message, pii) =>
            {
                PartnerSession.Instance.DebugMessages.Enqueue($"[MSAL] {level} {message}");
            }).Build();

            if (PartnerSession.Instance.TryGetComponent(ComponentKey.TokenCache, out IPartnerTokenCache tokenCache))
            {
                tokenCache.RegisterCache(client);
            }

            return client;
        }

        /// <summary>
        /// Creates a public client used for generating tokens.
        /// </summary>
        /// <param name="cloudInstance">The cloud instance used for authentication.</param>
        /// <param name="clientId">Identifier of the client requesting the token.</param>
        /// <param name="redirectUri">The redirect URI for the client.</param>
        /// <param name="tenantId">Identifier of the tenant requesting the token.</param>
        /// <returns>An aptly configured public client.</returns>
        private static IPublicClientApplication CreatePublicClient(
            AzureCloudInstance cloudInstance,
            string clientId = null,
            string redirectUri = null,
            string tenantId = null)
        {
            PublicClientApplicationBuilder builder = PublicClientApplicationBuilder.Create(clientId);

            builder = builder.WithAuthority(cloudInstance, tenantId);

            if (!string.IsNullOrEmpty(redirectUri))
            {
                builder = builder.WithRedirectUri(redirectUri);
            }

            if (!string.IsNullOrEmpty(tenantId))
            {
                builder = builder.WithTenantId(tenantId);
            }

            IPublicClientApplication client = builder.WithLogging((level, message, pii) =>
            {
                PartnerSession.Instance.DebugMessages.Enqueue($"[MSAL] {level} {message}");
            }).Build();


            if (PartnerSession.Instance.TryGetComponent(ComponentKey.TokenCache, out IPartnerTokenCache tokenCache))
            {
                tokenCache.RegisterCache(client);
            }

            return client;
        }

        /// <summary>
        /// Gets the Azure cloud instance based an instance of the <see cref="PartnerEnvironment" /> class.
        /// </summary>
        /// <param name="environment">The environment information used to be generate the Azure Cloud instance.</param>
        /// <returns>The Azure cloud instance based an instance of the <see cref="PartnerEnvironment" /> class.</returns>
        private static AzureCloudInstance GetAzureCloudInstance(PartnerEnvironment environment)
        {
            environment.AssertNotNull(nameof(environment));

            if (environment.EnvironmentName == EnvironmentName.AzureChinaCloud)
            {
                return AzureCloudInstance.AzureChina;
            }
            else if (environment.EnvironmentName == EnvironmentName.AzureGermanCloud)
            {
                return AzureCloudInstance.AzureGermany;
            }
            else if (environment.EnvironmentName == EnvironmentName.AzureCloud)
            {
                return AzureCloudInstance.AzurePublic;
            }
            else if (environment.EnvironmentName == EnvironmentName.AzureUSGovernment)
            {
                return AzureCloudInstance.AzureUsGovernment;
            }

            return AzureCloudInstance.None;
        }

        /// <summary>
        /// Gets the specified certificate.
        /// </summary>
        /// <param name="thumbprint">Thumbprint of the certificate to be located.</param>
        /// <returns>An instance of the <see cref="X509Certificate2"/> class that represents the certificate.</returns>
        private static X509Certificate2 GetCertificate(string thumbprint)
        {
            if (string.IsNullOrEmpty(thumbprint))
            {
                return null;
            }

            if (FindCertificateByThumbprint(thumbprint, StoreLocation.CurrentUser, out X509Certificate2 certificate) ||
                    FindCertificateByThumbprint(thumbprint, StoreLocation.LocalMachine, out certificate))
            {
                return certificate;
            }

            return null;
        }

        /// <summary>
        /// Locates a certificate by thumbprint.
        /// </summary>
        /// <param name="thumbprint">Thumbprint of the certificate to be located.</param>
        /// <param name="storeLocation">The location of the X.509 certifcate store.</param>
        /// <returns><c>true</c> if the certificate was found; otherwise <c>false</c>.</returns>
        private static bool FindCertificateByThumbprint(string thumbprint, StoreLocation storeLocation, out X509Certificate2 certificate)
        {
            X509Store store = null;
            X509Certificate2Collection col;

            thumbprint.AssertNotNull(nameof(thumbprint));

            try
            {
                store = new X509Store(StoreName.My, storeLocation);
                store.Open(OpenFlags.ReadOnly);

                col = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, false);

                certificate = col.Count == 0 ? null : col[0];

                return col.Count > 0;
            }
            finally
            {
                store?.Close();
            }
        }
    }
}