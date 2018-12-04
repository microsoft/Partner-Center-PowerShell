// -----------------------------------------------------------------------
// <copyright file="AuthenticationToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell
{
    using System;

    /// <summary>
    /// Represents an authentication token for a resource.
    /// </summary>
    public sealed class AuthenticationToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationToken" /> class.
        /// </summary>
        /// <param name="token">The authentication token.</param>
        /// <param name="expiryTime">The token expiry time.</param>
        public AuthenticationToken(string token, DateTimeOffset expiryTime)
        {
            ExpiryTime = expiryTime;
            Token = token;

            ExpiryBuffer = TimeSpan.FromSeconds(
                Convert.ToInt32(
                    PartnerService.Instance.Configuration.DefaultAuthenticationTokenExpiryBufferInSeconds));
        }

        /// <summary>
        /// Gets the amount of time to deduct from the actual expiry time. 
        /// </summary>
        /// <remarks>
        /// This is used to ensure that the token does not expire while processing is still in progress.
        /// </remarks>
        public TimeSpan ExpiryBuffer { get; private set; }

        /// <summary>
        /// Gets the token expiry time.
        /// </summary>
        public DateTimeOffset ExpiryTime { get; private set; }

        /// <summary>
        /// Gets the authentication token value.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Indicates whether the token has expired or not.
        /// </summary>
        /// <returns><c>true</c> if the token has expired; otherwis <c>false</c>.</returns>
        public bool IsExpired()
        {
            return DateTimeOffset.UtcNow > ExpiryTime.UtcDateTime - ExpiryBuffer;
        }
    }
}