// -----------------------------------------------------------------------
// <copyright file="DirectoryRoleOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerDirectoryRoles
{
    using System;
    using Extensions;

    /// <summary>
    /// Directory role operations class.
    /// </summary>
    internal class DirectoryRoleOperations : BasePartnerComponent<Tuple<string, string>>, IDirectoryRole
    {
        /// <summary>
        /// A lazy reference to the current directory role's user members operations.
        /// </summary>
        private readonly Lazy<IUserMemberCollection> directoryRoleUserMemberOperations;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectoryRoleOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer tenant identifier.</param>
        /// <param name="roleId">The directory role identifier.</param>
        public DirectoryRoleOperations(IPartner rootPartnerOperations, string customerId, string roleId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, roleId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            roleId.AssertNotEmpty(nameof(roleId));

            directoryRoleUserMemberOperations = new Lazy<IUserMemberCollection>(() => new UserMemberCollectionOperations(Partner, customerId, roleId));
        }

        /// <summary>
        /// Gets the current directory role's user member collection operations.
        /// </summary>
        public IUserMemberCollection UserMembers => directoryRoleUserMemberOperations.Value;
    }
}
