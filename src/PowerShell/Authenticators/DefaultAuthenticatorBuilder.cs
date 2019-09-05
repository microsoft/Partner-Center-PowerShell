// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;

    /// <summary>
    /// Default builder for chaining authenticators.
    /// </summary>
    public class DefaultAuthenticatorBuilder : IAuthenticatorBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAuthenticatorBuilder" /> class.
        /// </summary>
        public DefaultAuthenticatorBuilder()
        {
            AppendAuthenticator(() => { return new InteractiveUserAuthenticator(); });
            AppendAuthenticator(() => { return new DeviceCodeAuthenticator(); });
            AppendAuthenticator(() => { return new AccessTokenAuthenticator(); });
            AppendAuthenticator(() => { return new ServicePrincipalAuthenticator(); });
            AppendAuthenticator(() => { return new SilentAuthenticator(); });
            AppendAuthenticator(() => { return new RefreshTokenAuthenticator(); });
        }

        /// <summary>
        /// Gets the first authenticator in the chain.
        /// </summary>
        public IAuthenticator Authenticator { get; set; }

        /// <summary>
        /// Appends the authenticator to the chain.
        /// </summary>
        /// <param name="constructor">Delegate to initialize the authenticator.</param>
        public void AppendAuthenticator(Func<IAuthenticator> constructor)
        {
            if (null == Authenticator)
            {
                Authenticator = constructor();
                return;
            }

            IAuthenticator current;


            for (current = Authenticator; current != null && current.Next != null; current = current.Next)
            {
                ;
            }

            current.Next = constructor();
            return;
        }
    }
}
