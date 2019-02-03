// -----------------------------------------------------------------------
// <copyright file="AccountType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// Provides access to common constant values used for authentication.
    /// </summary>
    internal static class AuthenticationConstants
    {
        /// <summary>
        /// The common endpoint used during authentication.
        /// </summary>
        public const string CommonEndpoint = "common";

        /// <summary>
        /// The value for the redirect URI.
        /// </summary>
        public const string RedirectUriValue = "urn:ietf:wg:oauth:2.0:oob";
    }
}