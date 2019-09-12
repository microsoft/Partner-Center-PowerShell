// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Extensions;
    using Factories;
    using Identity.Client;
    using Models.Authentication;

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
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public abstract Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public abstract bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="account"></param>
        /// <param name="environment"></param>
        /// <param name="redirectUri"></param>
        /// <returns></returns>
        public IClientApplicationBase GetClient(PartnerAccount account, PartnerEnvironment environment, string redirectUri = null)
        {
            IClientApplicationBase app;

            if (account.IsPropertySet(PartnerAccountPropertyType.CertificateThumbprint) || account.IsPropertySet(PartnerAccountPropertyType.ServicePrincipalSecret))
            {
                app = SharedTokenCacheClientFactory.CreateConfidentialClient(
                    $"{environment.ActiveDirectoryAuthority}{account.Tenant}",
                    account.GetProperty(PartnerAccountPropertyType.ApplicationId),
                    account.GetProperty(PartnerAccountPropertyType.ServicePrincipalSecret),
                    GetCertificate(account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint)),
                    redirectUri,
                    account.Tenant);
            }
            else
            {
                app = SharedTokenCacheClientFactory.CreatePublicClient(
                    $"{environment.ActiveDirectoryAuthority}{account.Tenant}",
                    account.GetProperty(PartnerAccountPropertyType.ApplicationId),
                    redirectUri,
                    account.Tenant);
            }

            return app;
        }

        /// <summary>
        /// Gets the specified certificate.
        /// </summary>
        /// <param name="thumbprint">Thumbprint of the certificate to be located.</param>
        /// <returns>An instance of the <see cref="X509Certificate2"/> class that represents the certificate.</returns>
        private X509Certificate2 GetCertificate(string thumbprint)
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
        private bool FindCertificateByThumbprint(string thumbprint, StoreLocation storeLocation, out X509Certificate2 certificate)
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

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="token">The token based authentication information.</param>
        /// <returns><c>true</c> if the request can be authenticated; otherwise <c>false</c>.</returns>
        public bool TryAuthenticate(AuthenticationParameters parameters, out Task<AuthenticationResult> token)
        {
            token = null;

            if (CanAuthenticate(parameters))
            {
                token = AuthenticateAsync(parameters);
                return true;
            }

            if (Next != null)
            {
                return Next.TryAuthenticate(parameters, out token);
            }

            return false;
        }
    }
}