// -----------------------------------------------------------------------
// <copyright file="IAuthenticationFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using Authentication;

    /// <summary>
    /// Represents a factory used to perform authentication operations.
    /// </summary>
    public interface IAuthenticationFactory
    {
        /// <summary>
        /// Acquires the security token from the authority.
        /// </summary>
        /// <param name="context">Context to be used when requesting a security token.</param>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <param name="promptAction">The action to prompt the user for input.</param>
        /// <returns>The result from the authentication request.</returns>
        AuthenticationToken Authenticate(PartnerContext context, Action<string> debugAction, Action<string> promptAction = null);
    }
}