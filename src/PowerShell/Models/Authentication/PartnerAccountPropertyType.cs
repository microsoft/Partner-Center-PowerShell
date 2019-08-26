﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    /// <summary>
    /// Provides the string contants for known extended properties.
    /// </summary>
    public static class PartnerAccountPropertyType
    {
        /// <summary>
        /// Name of the access token extended property.
        /// </summary>
        public const string AccessToken = "AccessToken";

        /// <summary>
        /// Name of the certificate thumpbrint extended property.
        /// </summary>
        public const string CertificateThumbprint = "CertificateThumbprint";

        /// <summary>
        /// Name of the service principal secret extended property.
        /// </summary>
        public const string ServicePrincipalSecret = "ServicePrincipalSecret";

        /// <summary>
        /// Name of the tenant extended property.
        /// </summary>
        public const string Tenant = "Tenant";
    }
}