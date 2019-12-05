// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using System.Threading.Tasks;
    using Graph;
    using Rest;

    /// <summary>
    /// Represents a factory that provides initialized clients used to interact with online services.
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Creates a new instance of the Microsoft Graph service client.
        /// </summary>
        /// <returns>An instance of the <see cref="GraphServiceClient"/> class.</returns>
        IGraphServiceClient CreateGraphServiceClient();

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        IPartner CreatePartnerOperations();

        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        Task<IPartner> CreatePartnerOperationsAsync();

        /// <summary>
        /// Creates a new service client used interact with a specific service.
        /// </summary>
        /// <typeparam name="TClient">Type of service client being created.</typeparam>
        /// <param name="scopes">Scopes requested to access a protected service.</param>
        /// <param name="tenantId">The identifier for the tenant.</param>
        /// <returns>An instance of a service client that is connected to a specific service.</returns>
        Task<TClient> CreateServiceClientAsync<TClient>(string[] scopes, string tenantId = null) where TClient : ServiceClient<TClient>;
    }
}