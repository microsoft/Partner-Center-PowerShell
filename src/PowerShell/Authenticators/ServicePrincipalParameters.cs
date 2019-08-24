// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Security;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using app only authentication.
    /// </summary>
    public class ServicePrincipalParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePrincipalParameters" /> class.
        /// </summary>
        /// <param name="environment">The partner environment information.</param>
        /// <param name="resourceEndpoint">The resource endpoint address.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="applicationId"></param>
        /// <param name="secret"></param>
        /// <param name="thumbprint"></param>
        public ServicePrincipalParameters(PartnerEnvironment environment, string resourceEndpoint, string tenantId, string applicationId, string thumbprint, SecureString secret)
            : base(environment, resourceEndpoint, tenantId)
        {
            ApplicationId = applicationId;
            CertificateThumbprint = thumbprint;
            Secret = secret;
        }

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        public string ApplicationId { get; }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint { get; }

        /// <summary>
        /// Gets the application secret.
        /// </summary>
        public SecureString Secret { get; }
    }
}