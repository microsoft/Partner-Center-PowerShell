// -----------------------------------------------------------------------
// <copyright file="PowerShellCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Profile
{
    using System;

    /// <summary>
    /// Provides the credentials need to access the partner service.
    /// </summary>
    public class PowerShellCredentials : IPartnerCredentials
    {
        /// <summary>
        /// The result from a successfully token request.
        /// </summary>
        private readonly AuthenticationToken authToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellCredentials" /> class.
        /// </summary>
        /// <param name="authToken">The authentication token for Partner Center.</param>
        public PowerShellCredentials(AuthenticationToken authToken)
        {
            this.authToken = authToken;
        }

        /// <summary>
        ///  Gets the expiry time in UTC for the token.
        /// </summary>
        public DateTimeOffset ExpiresAt => authToken.ExpiryTime;

        /// <summary>
        /// Gets the token needed to authenticate with the partner service.
        /// </summary>
        public string PartnerServiceToken => authToken.Token;

        /// <summary>
        /// Indicates whether the partner credentials have expired or not.
        /// </summary>
        /// <returns><c>true</c> if the partner credentials have expired; otherwise <c>false</c>.</returns>
        public bool IsExpired()
        {
            return DateTimeOffset.UtcNow > authToken.ExpiryTime;
        }
    }
}