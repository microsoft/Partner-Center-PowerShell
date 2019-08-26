// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authentication.
    /// </summary>
    public abstract class AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationParameters" /> class.
        /// </summary>
        protected AuthenticationParameters(string applicationId, PartnerEnvironment environment, IEnumerable<string> scopes, string tenantId)
        {
            ApplicationId = applicationId;
            Environment = environment;
            Scopes = scopes;
            TenantId = tenantId;
        }

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        public string ApplicationId { get; }

        /// <summary>
        /// Gets the partner environment information.
        /// </summary>
        public PartnerEnvironment Environment { get; }

        /// <summary>
        /// Gets the scopes.
        /// </summary>
        public IEnumerable<string> Scopes { get; }

        /// <summary>
        /// Gets the tenant identifier.
        /// </summary>
        public string TenantId { get; }
    }
}