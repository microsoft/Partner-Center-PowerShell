// -----------------------------------------------------------------------
// <copyright file="AuthenticationResult.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Authentication
{
    using System;

    /// <summary>
    /// Contains the results of one token acquisition operation.
    /// </summary>
    public sealed class AuthenticationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationResult" /> class.
        /// </summary>
        /// <param name="authResponse"></param>
        internal AuthenticationResult(AuthenticationResponse authResponse)
        {
            AccessToken = authResponse.AccessToken;
            AccessTokenType = authResponse.TokenType;
            ExpiresOn = DateTime.UtcNow + TimeSpan.FromSeconds(authResponse.ExpiresIn);
            IdToken = authResponse.IdTokenString;
            RefreshToken = authResponse.RefreshToken;
        }

        /// <summary>
        /// Gets the access token requested.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the type of access token returned.
        /// </summary>
        public string AccessTokenType { get; private set; }

        /// <summary>
        /// Gets the point in time in which the access token returned in the <see cref="AccessToken" /> property ceases to be valid.
        /// </summary>
        /// <remarks>
        /// This value is calculated based on current UTC time measured locally and the value expiresIn received from the service.
        /// </remarks>
        public DateTimeOffset ExpiresOn { get; private set; }

        /// <summary>
        /// Gets the entire ID token if returned by the service or null if no ID token is returned.
        /// </summary>
        public string IdToken { get; private set; }

        /// <summary>
        /// Gets the refresh token associated with the requested access token. Note: not all operations will return a refresh token.
        /// </summary>
        public string RefreshToken { get; private set; }
    }
}