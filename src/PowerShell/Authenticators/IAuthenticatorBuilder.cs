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
        /// 
        /// </summary>
        IAuthenticator Authenticator { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="constructor"></param>
        /// <returns></returns>
        bool AppendAuthenticator(Func<IAuthenticator> constructor);
    }
}