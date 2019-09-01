// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Net.Http;
    using Extensions;
    using Identity.Client;
    using Models.Authentication;
    using Network;
    using Rest;

    /// <summary>
    /// Factory that provides initialized clients used to interact with online services.
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        /// <summary>
        /// The client used to perform HTTP operations.
        /// </summary>
        private static readonly HttpClient HttpClient = new HttpClient(new CancelRetryHandler(3, TimeSpan.FromSeconds(10))
        {
            InnerHandler = new RetryDelegatingHandler
            {
                InnerHandler = new HttpClientHandler()
            }
        });

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public virtual IPartner CreatePartnerOperations()
        {
            PartnerService.Instance.ApiRootUrl = new Uri(PartnerSession.Instance.Context.Environment.PartnerCenterEndpoint);

            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                PartnerSession.Instance.Context.Account,
                PartnerSession.Instance.Context.Environment,
                new[] { PartnerSession.Instance.Context.Account.GetProperty(PartnerAccountPropertyType.Scope) });

            return PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCredentials(new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn)),
                HttpClient);
        }
    }
}