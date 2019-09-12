// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating non-interactively.
    /// </summary>
    public class SilentParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilentParameters" /> class.
        /// </summary>
        public SilentParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes)
            : base(account, environment, scopes)
        {
        }

        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        public string UserId => Account.ObjectId;
    }
}