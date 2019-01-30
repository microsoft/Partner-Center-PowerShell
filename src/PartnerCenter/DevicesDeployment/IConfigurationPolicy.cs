// -----------------------------------------------------------------------
// <copyright file="IConfigurationPolicy.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.DevicesDeployment
{
    using System;
    using GenericOperations;
    using Models.DevicesDeployment;

    /// <summary>
    /// Represents all the operations that can be done on a configuration policy.
    /// </summary>
    public interface IConfigurationPolicy : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<ConfigurationPolicy>, IEntityPatchOperations<ConfigurationPolicy>, IEntityDeleteOperations<ConfigurationPolicy>
    {
    }
}