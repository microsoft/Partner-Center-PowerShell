// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using the device code flow.
    /// </summary>
    public class DeviceCodeParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCodeParameters" /> class.
        /// </summary>
        public DeviceCodeParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes)
            : base(account, environment, scopes)
        {
        }
    }
}