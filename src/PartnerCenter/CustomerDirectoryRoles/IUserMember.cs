// -----------------------------------------------------------------------
// <copyright file="IUserMember.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using GenericOperations;
    using Models.Roles;

    /// <summary>
    /// Represents the behavior of a user member.
    /// </summary>
    public interface IUserMember : IPartnerComponent<Tuple<string, string, string>>, IEntityDeleteOperations<UserMember>
    {
    }
}