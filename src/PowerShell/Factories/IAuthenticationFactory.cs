// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Collections.Generic;
    using Models.Authentication;

    /// <summary>
    /// Represents a factory used to perform authentication operations.
    /// </summary>
    public interface IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <returns>The result from the authentication request.</returns>
        AuthenticationToken Authenticate(PartnerAccount account, PartnerEnvironment environment, string secret, IEnumerable<string> scopes, string tenantId);
    }
}