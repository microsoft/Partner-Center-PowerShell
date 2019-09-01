// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Collections.Generic;
    using Extensions;
    using Models.Authentication;

    /// <summary>
    /// Represents the parameters used for authenticating using an access token.
    /// </summary>
    public class AccessTokenParameters : AuthenticationParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenParameters" /> class.
        /// </summary>
        public AccessTokenParameters(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes)
            : base(account, environment, scopes)
        {
        }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken => Account.GetProperty(PartnerAccountPropertyType.AccessToken);
    }
}