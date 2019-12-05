// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading.Tasks;
    using Extensions;
    using Graph;
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
        /// The service client used to communicate with Microsoft Graph.
        /// </summary>
        private static readonly IGraphServiceClient GraphServiceClient = new GraphServiceClient(null, new HttpProvider(new RetryDelegatingHandler
        {
            InnerHandler = new ClientTracingHandler
            {
                InnerHandler = new HttpClientHandler()
            }
        }, false, null));

        /// <summary>
        /// The client used to perform HTTP operations.
        /// </summary>
        private static readonly HttpClient HttpClient = new HttpClient(new RetryDelegatingHandler
        {
            InnerHandler = new HttpClientHandler()
        });

        /// <summary>
        /// Creates a new instance of the Microsoft Graph service client.
        /// </summary>
        /// <returns>An instance of the <see cref="Graph.GraphServiceClient"/> class.</returns>
        public IGraphServiceClient CreateGraphServiceClient()
        {
            return GraphServiceClient;
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public virtual IPartner CreatePartnerOperations()
        {
            return CreatePartnerOperationsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        public virtual async Task<IPartner> CreatePartnerOperationsAsync()
        {
            PartnerService.Instance.ApiRootUrl = new Uri(PartnerSession.Instance.Context.Environment.PartnerCenterEndpoint);

            AuthenticationResult authResult = await PartnerSession.Instance.AuthenticationFactory.AuthenticateAsync(
                PartnerSession.Instance.Context.Account,
                PartnerSession.Instance.Context.Environment,
                new[] { PartnerSession.Instance.Context.Account.GetProperty(PartnerAccountPropertyType.Scope) }).ConfigureAwait(false);

            return PartnerService.Instance.CreatePartnerOperations(
                new PowerShellCredentials(new AuthenticationToken(authResult.AccessToken, authResult.ExpiresOn)),
                HttpClient);
        }

        /// <summary>
        /// Creates a new service client used interact with a specific service.
        /// </summary>
        /// <typeparam name="TClient">Type of service client being created.</typeparam>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="tenantId">The identifier for the tenant.</param>
        /// <returns>An instance of a service client that is connected to a specific service.</returns>
        public virtual async Task<TClient> CreateServiceClientAsync<TClient>(string[] scopes, string tenantId = null) where TClient : ServiceClient<TClient>
        {
            PartnerAccount account = PartnerSession.Instance.Context.Account;

            if (!string.IsNullOrEmpty(tenantId))
            {
                account.Tenant = tenantId;
            }

            AuthenticationResult authResult = await PartnerSession.Instance.AuthenticationFactory.AuthenticateAsync(
                account,
                PartnerSession.Instance.Context.Environment,
                scopes).ConfigureAwait(false);

            return CreateServiceClient<TClient>(new TokenCredentials(authResult.AccessToken, "Bearer"), HttpClient, false);
        }

        private TClient CreateServiceClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            List<Type> types = new List<Type>();
            List<object> parameterList = new List<object>();

            foreach (object obj in parameters)
            {
                types.Add(obj.GetType());
                parameterList.Add(obj);
            }

            ConstructorInfo constructor = typeof(TClient).GetConstructor(types.ToArray());

            if (constructor == null)
            {
                throw new InvalidOperationException($"{typeof(TClient).Name} is an invalid management client");
            }

            return (TClient)constructor.Invoke(parameterList.ToArray());
        }
    }
}