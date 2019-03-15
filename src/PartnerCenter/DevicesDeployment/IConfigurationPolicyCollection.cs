// -----------------------------------------------------------------------
// <copyright file="IConfigurationPolicyCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using GenericOperations;
    using Models;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents the operations that can be done on the partner's configuration policies.
    /// </summary>
    public interface IConfigurationPolicyCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<ConfigurationPolicy, ResourceCollection<ConfigurationPolicy>>, IEntityCreateOperations<ConfigurationPolicy, ConfigurationPolicy>, IEntitySelector<string, IConfigurationPolicy>
    {
    }
}