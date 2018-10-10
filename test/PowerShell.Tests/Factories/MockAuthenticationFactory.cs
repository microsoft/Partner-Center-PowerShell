// -----------------------------------------------------------------------
// <copyright file="MockAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using IdentityModel.Clients.ActiveDirectory;
    using PowerShell.Factories;
    using Profile;

    /// <summary>
    /// Factory that mocks authenticaton operations.
    /// </summary>
    public class MockAuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Contexted to be used when requesting a security token.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationResult Authenticate(PartnerContext context)
        {
            return AuthenticationResult.Deserialize("{}");
        }
    }
}
