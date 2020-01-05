// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Identity.Client;
    using Models.Authentication;

    /// <summary>
    /// Represents a factory used to perform authentication operations.
    /// </summary>
    public interface IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="account">The account information to be used when generating the client.</param>
        /// <param name="environment">The environment where the client is connecting.</param>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="message">The message to be written to the console.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result from the authentication request.</returns>
        Task<AuthenticationResult> AuthenticateAsync(PartnerAccount account, PartnerEnvironment environment, IEnumerable<string> scopes, string message = null, CancellationToken cancellationToken = default);
    }
}