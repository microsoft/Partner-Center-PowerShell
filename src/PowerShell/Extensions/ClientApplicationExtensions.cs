// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Extensions
{
    using Identity.Client;

    /// <summary>
    /// Extension methods for converting client applications.
    /// </summary>
    public static class ClientApplicationExtensions
    {
        /// <summary>
        /// Converts the client application to a confidential client.
        /// </summary>
        /// <param name="app">The base client application to be converted.</param>
        /// <returns>A confidential client represents the client application.</returns>
        public static IConfidentialClientApplication AsConfidentialClient(this IClientApplicationBase app)
        {
            return app as IConfidentialClientApplication;
        }

        /// <summary>
        /// Converts the client application to a public client.
        /// </summary>
        /// <param name="app">The base client application to be converted.</param>
        /// <returns>A public client represents the client application.</returns>
        public static IPublicClientApplication AsPublicClient(this IClientApplicationBase app)
        {
            return app as IPublicClientApplication;
        }

        /// <summary>
        /// Converts the client application to a refresh token client.
        /// </summary>
        /// <param name="app">The base client application to be converted.</param>
        /// <returns>A refresh token client represents the client application.</returns>
        public static IByRefreshToken AsRefreshTokenClient(this IClientApplicationBase app)
        {
            return app as IByRefreshToken;
        }
    }
}