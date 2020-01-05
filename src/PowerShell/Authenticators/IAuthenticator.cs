// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System.Threading;
    using System.Threading.Tasks;
    using Identity.Client;

    /// <summary>
    /// Represents an authenticator with distributed responsibility.
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Gets or sets the next authenticator in the chain.
        /// </summary>
        IAuthenticator NextAuthenticator { get; set; }

        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        Task<AuthenticationResult> TryAuthenticateAsync(AuthenticationParameters parameters, CancellationToken cancellationToken = default);
    }
}