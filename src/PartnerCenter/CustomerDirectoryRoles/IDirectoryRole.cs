// -----------------------------------------------------------------------
// <copyright file="IDirectoryRole.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;

    /// <summary>
    /// Represents the behavior of directory role.
    /// </summary>
    public interface IDirectoryRole : IPartnerComponent<Tuple<string, string>>
    {
        /// <summary>
        /// Gets the current directory role's user member collection operations.
        /// </summary>
        IUserMemberCollection UserMembers { get; }
    }
}