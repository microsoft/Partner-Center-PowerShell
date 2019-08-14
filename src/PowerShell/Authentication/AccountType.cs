// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authentication
{
    /// <summary>
    /// The available account types used for authentication.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Indicates that an access token will be used for authentication.
        /// </summary>
        AccessToken,

        /// <summary>
        /// Indiciates that a service principal will be used for authentication.
        /// </summary>
        ServicePrincipal,

        /// <summary>
        /// Indicates that a user will be used for authentication.
        /// </summary>
        User
    }
}