// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Extensions;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using a refresh token.
    /// </summary>
    public class RefreshTokenParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshTokenParameters" /> class.
        /// </summary>
        public RefreshTokenParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes)
            : base(account, environment, scopes)
        {
        }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint => Account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint);

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public string RefreshToken => Account.GetProperty(PartnerAccountPropertyType.RefreshToken);

        /// <summary>
        /// Gets the application secret.
        /// </summary>
        public string Secret => Account.GetProperty(PartnerAccountPropertyType.ServicePrincipalSecret);
    }
}