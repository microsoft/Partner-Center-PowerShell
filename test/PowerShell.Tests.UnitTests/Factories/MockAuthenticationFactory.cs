// -----------------------------------------------------------------------
// <copyright file="MockAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.UnitTests.Factories
{
    using System;
    using Authentication;
    using PowerShell.Factories;

    /// <summary>
    /// Factory that mocks authenticaton operations.
    /// </summary>
    public class MockAuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <param name="promptAction">The action to prompt the user for input.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationToken Authenticate(PartnerContext context, Action<string> debugAction, Action<string> promptAction = null)
        {
            return new AuthenticationToken("STUB_TOKEN", DateTime.UtcNow.AddHours(1));
        }
    }
}