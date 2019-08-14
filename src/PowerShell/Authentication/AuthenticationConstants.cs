// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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