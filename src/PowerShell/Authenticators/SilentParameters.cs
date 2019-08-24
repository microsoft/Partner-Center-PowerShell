// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using Models.Authentication; 

    /// <summary>
    /// Represents the parameters used for authenticating non-interactively.
    /// </summary>
    public class SilentParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilentParameters" /> class.
        /// </summary>
        /// <param name="environment">The partner environment information.</param>
        /// <param name="resourceEndpoint">The resource endpoint address.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="userId">The user identifier.</param>
        public SilentParameters(PartnerEnvironment environment, string resourceEndpoint, string tenantId, string userId)
            : base(environment, resourceEndpoint, tenantId)
        {
            UserId = userId;
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public string UserId { get; }
    }
}