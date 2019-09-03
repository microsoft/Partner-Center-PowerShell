﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Extensions;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating interactively
    /// </summary>
    public class InteractiveParameters : DeviceCodeParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractiveParameters" /> class.
        /// </summary>
        public InteractiveParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes)
            : base(account, environment, scopes)
        {
        }

        /// <summary>
        /// Gets the certificate thumbprint.
        /// </summary>
        public string CertificateThumbprint => Account.GetProperty(PartnerAccountPropertyType.CertificateThumbprint);

        /// <summary>
        /// Gets the application secret.
        /// </summary>
        public string Secret => Account.GetProperty(PartnerAccountPropertyType.ServicePrincipalSecret);
    }
}