// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using Models.Authentication; 

    /// <summary>
    /// Represents the parameters used for authentication.
    /// </summary>
    public abstract class AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationParameters" /> class.
        /// </summary>
        /// <param name="environment">The partner environment information.</param>
        /// <param name="resourceEndpoint">The resource endpoint address.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        protected AuthenticationParameters(PartnerEnvironment environment, string resourceEndpoint, string tenantId)
        {
            Environment = environment;
            ResourceEndpoint = resourceEndpoint;
            TenantId = tenantId;
        }

        /// <summary>
        /// Gets the partner environment information.
        /// </summary>
        public PartnerEnvironment Environment { get; }

        /// <summary>
        /// Gets the resource endpoint address.
        /// </summary>
        public string ResourceEndpoint { get; }

        /// <summary>
        /// Gets the tenant identifier.
        /// </summary>
        public string TenantId { get; }
    }
}