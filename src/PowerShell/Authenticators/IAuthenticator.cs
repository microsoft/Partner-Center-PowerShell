// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
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
        IAuthenticator Next { get; set; }

        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationToken" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        Task<AuthenticationResult> AuthenticateAsync(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="token">The token based authentication information.</param>
        /// <returns><c>true</c> if the request can be authenticated; otherwise <c>false</c>.</returns>
        bool TryAuthenticate(AuthenticationParameters parameters, out Task<AuthenticationResult> token);
    }
}