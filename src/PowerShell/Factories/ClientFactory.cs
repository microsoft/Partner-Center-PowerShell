// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Reflection;
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
        private static readonly CancelRetryHandler DefaultCancelRetryHandler = new CancelRetryHandler(3, TimeSpan.FromSeconds(10));

        /// <summary>
        /// The service client used to communicate with Microsoft Graph.
        /// </summary>
        private static readonly IGraphServiceClient GraphServiceClient = new GraphServiceClient(null, new HttpProvider(new CancelRetryHandler(3, TimeSpan.FromSeconds(10))
        {
            InnerHandler = new RetryDelegatingHandler
            {
                InnerHandler = new HttpClientHandler()
            }
        }, false, null));

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
            PartnerService.Instance.ApiRootUrl = new Uri(PartnerSession.Instance.Context.Environment.PartnerCenterEndpoint);

            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                PartnerSession.Instance.Context.Account,
                PartnerSession.Instance.Context.Environment,
                new[] { PartnerSession.Instance.Context.Account.GetProperty(PartnerAccountPropertyType.Scope) });

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
        public virtual TClient CreateServiceClient<TClient>(string[] scopes, string tenantId = null) where TClient : ServiceClient<TClient>
        {
            PartnerAccount account = PartnerSession.Instance.Context.Account;

            if (!string.IsNullOrEmpty(tenantId))
            {
                account.Tenant = tenantId;
            }

            AuthenticationResult authResult = PartnerSession.Instance.AuthenticationFactory.Authenticate(
                account,
                PartnerSession.Instance.Context.Environment,
                scopes);

            return CreateServiceClient<TClient>(new TokenCredentials(authResult.AccessToken, "Bearer"));
        }

        private TClient CreateServiceClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>
        {
            List<Type> types = new List<Type>();
            List<object> parameterList = new List<object>();

            List<DelegatingHandler> handlerList = new List<DelegatingHandler> { DefaultCancelRetryHandler.Clone() as CancelRetryHandler };

            foreach (object obj in parameters)
            {
                Type paramType = obj.GetType();
                types.Add(paramType);
                parameterList.Add(obj);
            }

            types.Add((Array.Empty<DelegatingHandler>()).GetType());
            parameterList.Add(handlerList.ToArray());

            ConstructorInfo constructor = typeof(TClient).GetConstructor(types.ToArray());

            if (constructor == null)
            {
                throw new InvalidOperationException($"{typeof(TClient).Name} is an invalid management client");
            }

            return (TClient)constructor.Invoke(parameterList.ToArray());
        }
    }
}