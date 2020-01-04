// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.UnitTests.Factories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Graph;
    using Network;
    using PowerShell.Factories;
    using Rest;

    /// <summary>
    /// Factory that provides initialized clients used to mock interactions with online services.
    /// </summary>
    public class MockClientFactory : IClientFactory
    {
        /// <summary>
        /// Delegating handler used to intercept partner service client operations.
        /// </summary>
        private readonly HttpMockHandler httpMockHandler;

        /// <summary>
        /// Credentials used when communicating with the partner service.
        /// </summary>
        private readonly IPartnerCredentials credentials;

        /// <summary>
        /// Provides the ability to interact with Microsoft Graph.
        /// </summary>
        private static IGraphServiceClient graphServiceClient;

        /// <summary>
        /// Provides the ability to interact with the partner service.
        /// </summary>
        private static IPartner partnerOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockClientFactory" /> class.
        /// </summary>
        /// <param name="httpMockHandler">The delegating handler used test HTTP operations.</param>
        /// <param name="credentials">Credentials used when communicating with the partner service.</param>
        public MockClientFactory(HttpMockHandler httpMockHandler, IPartnerCredentials credentials)
        {
            this.credentials = credentials;
            this.httpMockHandler = httpMockHandler;
        }

        /// <summary>
        /// Creates a new instance of the Microsoft Graph service client.
        /// </summary>
        /// <returns>An instance of the <see cref="Graph.GraphServiceClient"/> class.</returns>
        public IGraphServiceClient CreateGraphServiceClient()
        {
            if (graphServiceClient == null)
            {
                graphServiceClient = new GraphServiceClient(null, new HttpProvider(new RetryDelegatingHandler
                {
                    InnerHandler = httpMockHandler
                }, false, null));
            }

            return graphServiceClient;
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <param name="correlationId">The correlation identifier for the request context.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public virtual async Task<IPartner> CreatePartnerOperationsAsync(Guid correlationId = default, CancellationToken cancellationToken = default)
        {
            if (partnerOperations == null)
            {
                partnerOperations = TestPartnerService.CreatePartnerOperations(
                    credentials,
                    httpMockHandler);
            }

            await Task.CompletedTask.ConfigureAwait(false);

            return partnerOperations;
        }

        /// <summary>
        /// Creates a new service client used interact with a specific service.
        /// </summary>
        /// <typeparam name="TClient">Type of service client being created.</typeparam>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="tenantId">The identifier for the tenant.</param>
        /// <returns>An instance of a service client that is connected to a specific service.</returns>
        public Task<TClient> CreateServiceClientAsync<TClient>(string[] scopes, string tenantId = null) where TClient : ServiceClient<TClient>
        {
            throw new NotImplementedException();
        }
    }
}