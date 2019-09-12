// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using Identity.Client;

    public static class ClientApplicationExtensions
    {
        public static IConfidentialClientApplication AsConfidentialClient(this IClientApplicationBase app)
        {
            return app as IConfidentialClientApplication;
        }

        public static IPublicClientApplication AsPublicClient(this IClientApplicationBase app)
        {
            return app as IPublicClientApplication;
        }

        public static IByRefreshToken AsRefreshTokenClient(this IClientApplicationBase app)
        {
            return app as IByRefreshToken;
        }
    }
}