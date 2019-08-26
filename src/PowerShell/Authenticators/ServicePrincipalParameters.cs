﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using app only authentication.
    /// </summary>
    public class ServicePrincipalParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicePrincipalParameters" /> class.
        /// </summary>
        public ServicePrincipalParameters(string applicationId, PartnerEnvironment environment, string secret, IEnumerable<string> scopes, string tenantId, string thumbprint)
            : base(applicationId, environment, scopes, tenantId)
        {
            CertificateThumbprint = thumbprint;
            Secret = secret;
        }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint { get; }

        /// <summary>
        /// Gets the application secret.
        /// </summary>
        public string Secret { get; }
    }
}