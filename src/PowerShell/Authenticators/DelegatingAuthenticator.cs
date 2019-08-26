// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using Identity.Client;

    /// <summary>
    /// Provides a chain of responsibility pattern for authenticators.
    /// </summary>
    internal abstract class DelegatingAuthenticator : IAuthenticator
    {
        /// <summary>
        /// Gets or sets the next authenticator in the chain.
        /// </summary>
        public IAuthenticator Next { get; set; }

        /// <summary>
        /// Apply this authenticator to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns>
        /// An instance of <see cref="AuthenticationResult" /> that represents the access token generated as result of a successful authenication. 
        /// </returns>
        public abstract AuthenticationResult Authenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this authenticator can apply to the given authentication parameters.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <returns><c>true</c> if this authenticator can apply; otherwise <c>false</c>.</returns>
        public abstract bool CanAuthenticate(AuthenticationParameters parameters);

        /// <summary>
        /// Determine if this request can be authenticated using the given authenticator, and authenticate if it can.
        /// </summary>
        /// <param name="parameters">The complex object containing authentication specific information.</param>
        /// <param name="token">The token based authentication information.</param>
        /// <returns><c>true</c> if the request can be authenticated; otherwise <c>false</c>.</returns>
        public bool TryAuthenticate(AuthenticationParameters parameters, out AuthenticationResult token)
        {
            token = null;

            if (CanAuthenticate(parameters))
            {
                token = Authenticate(parameters);
                return true;
            }

            if (Next != null)
            {
                return Next.TryAuthenticate(parameters, out token);
            }

            return false;
        }
    }
}