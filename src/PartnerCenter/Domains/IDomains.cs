// -----------------------------------------------------------------------
// <copyright file="IDomain.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Domains
{
    using GenericOperations;

    /// <summary>
    /// Represents the behavior of a domain.
    /// </summary>
    public interface IDomain : IPartnerComponent<string>, IEntityExistsOperations
    {
    }
}
