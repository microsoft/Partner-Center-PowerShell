// -----------------------------------------------------------------------
// <copyright file="MockAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using System;
    using System.Security;
    using IdentityModel.Clients.ActiveDirectory;
    using PowerShell.Factories;
    using Profile;

    /// <summary>
    /// Factory that mocks authenticaton operations.
    /// </summary>
    public class MockAuthenticationFactory : IAuthenticationFactory
    {
        /// <summary>
        /// Acquires a security token from the authority.
        /// </summary>
        /// <param name="applicationId">Identifier of the client requesting the token.</param>
        /// <param name="account">Account information used when requesting the token.</param>
        /// <param name="password">Password, or secret, used when requesting the token.</param>
        /// <param name="environmentName">Name of the environment to be used when requesting the token.</param>
        /// <param name="tokenCache">Token cache used to lookup cached tokens.</param>
        /// <returns>The access token and related information.</returns>
        public AuthenticationResult Authenticate(
            string applicationId,
            AzureAccount account,
            SecureString password,
            EnvironmentName environmentName,
            TokenCache tokenCache)
        {
            return null;
        }

        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="password">Password used when requesting a security token.</param>
        /// <returns>The result from the authentication request.</returns>
        public AuthenticationToken Authenticate(PartnerContext context, SecureString password = null)
        {
            return new AuthenticationToken("STUB_TOKEN", DateTime.UtcNow.AddHours(1));
        }
    }
}