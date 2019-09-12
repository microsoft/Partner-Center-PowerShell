// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Authentication
{
    /// <summary>
    /// Represents an item from the token cache.
    /// </summary>
    internal sealed class TokenCacheItem
    {
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the credential type.
        /// </summary>
        public string CredentialType { get; set; }

        /// <summary>
        /// Gets or sets the environment.   
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the home account identifier.
        /// </summary>
        public string HomeAccountId { get; set; }

        /// <summary>
        /// Gets or sets the raw client information.
        /// </summary>
        public string RawClientInfo { get; set; }

        /// <summary>
        /// Gets or sets the secret.
        /// </summary>
        public string Secret { get; set; }
    }
}