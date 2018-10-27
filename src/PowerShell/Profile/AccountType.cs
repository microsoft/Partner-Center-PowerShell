// -----------------------------------------------------------------------
// <copyright file="AccountType.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Profile
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