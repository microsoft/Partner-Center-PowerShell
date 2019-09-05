// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;

    /// <summary>
    /// Represents a builder for chaining authenticators.
    /// </summary>
    public interface IAuthenticatorBuilder
    {
        /// <summary>
        /// Gets the first authenticator in the chain.
        /// </summary>
        IAuthenticator Authenticator { get; }

        /// <summary>
        /// Appends the authenticator to the chain.
        /// </summary>
        /// <param name="constructor">Delegate to initialize the authenticator.</param>
        void AppendAuthenticator(Func<IAuthenticator> constructor);
    }
}