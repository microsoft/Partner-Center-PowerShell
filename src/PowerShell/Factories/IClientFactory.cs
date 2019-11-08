// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Factories
{
    using Rest;

    /// <summary>
    /// Represents a factory that provides initialized clients used to interact with online services.
    /// </summary>
    public interface IClientFactory
    {
        /// <summary>
        /// Creates a new instance of the object used to interface with Partner Center.
        /// </summary>
        /// <returns>An instance of the <see cref="PartnerOperations" /> class.</returns>
        IPartner CreatePartnerOperations();

        TClient CreateServiceClient<TClient>(string[] scopes) where TClient : ServiceClient<TClient>;

        TClient CreateServiceClient<TClient>(params object[] parameters) where TClient : ServiceClient<TClient>;
    }
}