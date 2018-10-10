// -----------------------------------------------------------------------
// <copyright file="PowerShellCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Profile
{
    using System;
    using IdentityModel.Clients.ActiveDirectory;

    /// <summary>
    /// Provides the credentials need to access the partner service.
    /// </summary>
    public class PowerShellCredentials : IPartnerCredentials
    {
        /// <summary>
        /// The result from a successfully token request.
        /// </summary>
        private readonly AuthenticationResult authResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerShellCredentials" /> class.
        /// </summary>
        /// <param name="authResult">The authentication result that contains the access token.</param>
        public PowerShellCredentials(AuthenticationResult authResult)
        {
            this.authResult = authResult;
        }

        /// <summary>
        ///  Gets the expiry time in UTC for the token.
        /// </summary>
        public DateTimeOffset ExpiresAt => authResult.ExpiresOn;

        /// <summary>
        /// Gets the token needed to authenticate with the partner service.
        /// </summary>
        public string PartnerServiceToken => authResult.AccessToken;

        /// <summary>
        /// Indicates whether the partner credentials have expired or not.
        /// </summary>
        /// <returns><c>true</c> if the partner credentials have expired; otherwise <c>false</c>.</returns>
        public bool IsExpired()
        {
            return DateTimeOffset.UtcNow > authResult.ExpiresOn;
        }
    }
}