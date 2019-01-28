// -----------------------------------------------------------------------
// <copyright file="ICustomerUserRoleCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using GenericOperations;
    using Models;
    using Models.Roles;

    /// <summary>
    /// Represents the behavior of the customers user's directory roles.
    /// </summary>
    public interface ICustomerUserRoleCollection : IPartnerComponent<Tuple<string, string>>, IEntireEntityCollectionRetrievalOperations<DirectoryRole, ResourceCollection<DirectoryRole>>
    {
    }
}
