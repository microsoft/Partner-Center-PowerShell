// -----------------------------------------------------------------------
// <copyright file="TokenRefresher.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System.Threading.Tasks;

    /// <summary>
    /// Defines a delegate used to retrieve updated tokens.
    /// </summary>
    /// <param name="expiredAuthenticationToken">The authentication token which has expired.</param>
    /// <returns>A delegate used to retrieve updated tokens.</returns>
    public delegate Task<AuthenticationToken> TokenRefresher(AuthenticationToken expiredAuthenticationToken);
}
