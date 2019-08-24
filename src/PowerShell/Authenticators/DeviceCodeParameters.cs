// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using the device code flow.
    /// </summary>
    public class DeviceCodeParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCodeParameters" /> class.
        /// </summary>
        /// <param name="environment">The partner environment information.</param>
        /// <param name="resourceEndpoint">The resource endpoint address.</param>
        /// <param name="tenantId">The tenant identifier.</param>
        public DeviceCodeParameters(PartnerEnvironment environment, string resourceEndpoint, string tenantId)
            : base(environment, resourceEndpoint, tenantId)
        {
        }
    }
}