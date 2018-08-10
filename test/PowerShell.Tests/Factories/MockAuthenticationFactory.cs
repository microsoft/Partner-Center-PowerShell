// -----------------------------------------------------------------------
// <copyright file="MockAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Tests.Factories
{
    using System;
    using System.Security;
    using Authentication;
    using Common;
    using IdentityModel.Clients.ActiveDirectory;
    using PowerShell.Factories;

    /// <summary>
    /// Factory that mocks authenticaton operations.
    /// </summary>
    public class MockAuthenticationFactory : IAuthenticationFactory
    {
        public PartnerContext Authenticate(string applicationId, EnvironmentName environment, string username, SecureString password, string tenantId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Authenticates the user using the specified parameters.
        /// </summary>
        /// <param name="context">The partner's execution context.</param>
        /// <param name="password">The password used to authenicate the user. This value can be null.</param>
        /// <returns>The result from the authentication request.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="context"/> is null.
        /// </exception>
        public AuthenticationResult Authenticate(PartnerContext context, SecureString password)
        {
            context.AssertNotNull(nameof(context));

            throw new NotImplementedException();
        }
    }
}
