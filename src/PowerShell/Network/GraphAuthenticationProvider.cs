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
        /// The identifier of the tenant that owns the resources being accessed.
        /// </summary>
        private readonly string tenantId;

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphAuthenticationProvider" /> class.
        /// </summary>
        /// <param name="tenantId">The identifier of the tenant that owns the resources being accessed.</param>
        public GraphAuthenticationProvider(string tenantId = null)
        {
            this.tenantId = tenantId;
        }

        /// <summary>
        /// Authenticates the specified request message.
        /// </summary>
        /// <param name="request">The HTTP request to be authenticated.</param>
        /// <returns>An instance of the <see cref="Task"/> class that represents the asynchronous operation.</returns>
        public async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            request.AssertNotNull(nameof(request));

            PartnerAccount account = PartnerSession.Instance.Context.Account.Clone();

            if (!string.IsNullOrEmpty(tenantId))
            {
                account.Tenant = tenantId;
            }

            AuthenticationResult authResult = await PartnerSession.Instance.AuthenticationFactory.AuthenticateAsync(
                account,
                PartnerSession.Instance.Context.Environment,
                new[] { $"{PartnerSession.Instance.Context.Environment.GraphEndpoint}/.default" }).ConfigureAwait(false);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            await Task.CompletedTask.ConfigureAwait(false);
        }
    }
}