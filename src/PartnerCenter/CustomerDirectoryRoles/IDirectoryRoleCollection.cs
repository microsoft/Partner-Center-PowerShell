// -----------------------------------------------------------------------
// <copyright file="IDirectoryRoleCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using GenericOperations;
    using Models;
    using Models.Roles;

    /// <summary>
    /// Represents the behavior of directory role collection.
    /// </summary>
    public interface IDirectoryRoleCollection : IPartnerComponent<string>, IEntireEntityCollectionRetrievalOperations<DirectoryRole, ResourceCollection<DirectoryRole>>, IEntitySelector<string, IDirectoryRole>
    {
    }
}