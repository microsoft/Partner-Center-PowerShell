// -----------------------------------------------------------------------
// <copyright file="IAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Security;
    using Authentication;
    using IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Represents a factory that handles authentication operations.
    /// </summary>
    public interface IAuthenticationFactory
    {
        PartnerContext Authenticate(string applicationId, EnvironmentName environment, string username, SecureString password, string tenantId);

        /// <summary>
        /// Authenticates the user using the specified parameters.
        /// </summary>
        /// <param name="context">Partner and user details used by the Partner Center cmdlets.</param>
        /// <param name="password">The password used to authenicate the user. This value can be null.</param>
        /// <returns>The result from the authentication request.</returns>
        AuthenticationResult Authenticate(PartnerContext context, SecureString password);
    }
}