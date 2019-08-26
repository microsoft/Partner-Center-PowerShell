// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using System.Collections.Generic;
    using System.Reflection;
    using Identity.Client;

    public static class MsalExtensions
    {
        public static AcquireTokenByRefreshTokenParameterBuilder AcquireTokenByRefreshToken(this IConfidentialClientApplication app, IEnumerable<string> scopes, string refreshToken)
        {
            MethodInfo method = app.GetType().GetMethod("Microsoft.Identity.Client.IByRefreshToken.AcquireTokenByRefreshToken", BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(app, new object[] { scopes, refreshToken }) as AcquireTokenByRefreshTokenParameterBuilder;
        }

        public static AcquireTokenByRefreshTokenParameterBuilder AcquireTokenByRefreshToken(this IPublicClientApplication app, IEnumerable<string> scopes, string refreshToken)
        {
            MethodInfo method = app.GetType().GetMethod("Microsoft.Identity.Client.IByRefreshToken.AcquireTokenByRefreshToken", BindingFlags.NonPublic | BindingFlags.Instance);
            return method.Invoke(app, new object[] { scopes, refreshToken }) as AcquireTokenByRefreshTokenParameterBuilder;
        }
    }
}