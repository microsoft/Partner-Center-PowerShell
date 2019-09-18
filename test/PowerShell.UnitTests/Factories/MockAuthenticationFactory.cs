// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Factories
{
    using System;
    using System.Collections.Generic;
    using Identity.Client;
    using PowerShell.Factories;
    using PowerShell.Models.Authentication;

    /// <summary>
    /// Factory that mocks authenticaton operations.
    /// </summary>
    public class MockAuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationResult Authenticate(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes, string message)
        {
            return new AuthenticationResult(
                "STUB_TOKEN",
                true,
                "uniquedId",
                DateTimeOffset.UtcNow.AddHours(1),
                DateTimeOffset.UtcNow.AddHours(1),
                "xxxx-xxxx-xxxx-xxxx",
                null,
                "STUB_TOKEN",
                scopes);
        }

    }
}