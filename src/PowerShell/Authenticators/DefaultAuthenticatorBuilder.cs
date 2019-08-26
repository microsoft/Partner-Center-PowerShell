// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Authenticators
{
    using System;

    public class DefaultAuthenticatorBuilder : IAuthenticatorBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultAuthenticatorBuilder" /> class.
        /// </summary>
        public DefaultAuthenticatorBuilder()
        {
            AppendAuthenticator(() => { return new InteractiveUserAuthenticator(); });
            AppendAuthenticator(() => { return new DeviceCodeAuthenticator(); });
            AppendAuthenticator(() => { return new ServicePrincipalAuthenticator(); });
            AppendAuthenticator(() => { return new SilentAuthenticator(); });
        }

        public IAuthenticator Authenticator { get; set; }

        public bool AppendAuthenticator(Func<IAuthenticator> constructor)
        {
            if (null == Authenticator)
            {
                Authenticator = constructor();
                return true;
            }

            IAuthenticator current;

            for (current = Authenticator; current != null && current.Next != null; current = current.Next)
            {
                ;
            }

            current.Next = constructor();
            return true;
        }
    }
}
