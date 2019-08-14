﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Net.Http;
    using Authentication;
    using Common;
    using Rest;

    /// <summary>
    /// Factory that provides initialized clients used to interact with online services.
    /// </summary>
    public class ClientFactory : IClientFactory
    {
        /// <summary>
        /// The client used to perform HTTP operations.
        /// </summary>
        private readonly static HttpClient HttpClient = new HttpClient(new CancelRetryHandler(3, TimeSpan.FromSeconds(10))
        {
            InnerHandler = new RetryDelegatingHandler
            {
                InnerHandler = new HttpClientHandler()
            }
        });


        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="debugAction">The action to write debug statements.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="debugAction" /> is null.
        /// </exception>
        public virtual IPartner CreatePartnerOperations(Action<string> debugAction)
        {
            debugAction.AssertNotNull(nameof(debugAction));

            PartnerEnvironment env = PartnerEnvironment.PublicEnvironments[PartnerSession.Instance.Context.Environment];

            PartnerService.Instance.ApiRootUrl = new Uri(env.PartnerCenterEndpoint);

            return PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCredentials(
                    PartnerSession.Instance.AuthenticationFactory.Authenticate(PartnerSession.Instance.Context, debugAction)),
                HttpClient);
        }
    }
}