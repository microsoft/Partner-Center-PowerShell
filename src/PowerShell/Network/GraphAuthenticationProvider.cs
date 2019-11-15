// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Network
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Graph;
    using Microsoft.Identity.Client;
    using Models.Authentication;

    /// <summary>
    /// Provides authentication for interacting with Microsoft Graph.
    /// </summary>
    public class GraphAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request">The HTTP request to be authenticated.</param>
        /// <returns>An instance of the <see cref="Task"/> class that represents the asynchronous operation.</returns>
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                PartnerSession.Instance.Context.Account,
                PartnerSession.Instance.Context.Environment,
                new[] { $"{PartnerSession.Instance.Context.Environment.GraphEndpoint}/.default" });

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            await Task.CompletedTask;
        }
    }
}