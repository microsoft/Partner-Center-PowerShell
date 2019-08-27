// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using a refresh token.
    /// </summary>
    public class RefreshTokenParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshTokenParameters" /> class.
        /// </summary>
        public RefreshTokenParameters(string applicationId, PartnerEnvironment environment, string refreshToken, string secret, IEnumerable<string> scopes, string tenantId, string thumbprint)
            : base(applicationId, environment, scopes, tenantId)
        {
            CertificateThumbprint = thumbprint;
            RefreshToken = refreshToken;
            Secret = secret;
        }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint { get; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public string RefreshToken { get; }

        /// <summary>
        /// Gets the application secret.
        /// </summary>
        public string Secret { get; }
    }
}