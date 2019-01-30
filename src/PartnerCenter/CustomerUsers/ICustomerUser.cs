// -----------------------------------------------------------------------
// <copyright file="ICustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.CustomerUsers
{
    using System;
    using GenericOperations;
    using Models.Users;

    /// <summary>
    /// Encapsulates a customer user behavior.
    /// </summary>
    public interface ICustomerUser : IPartnerComponent<Tuple<string, string>>, IEntityGetOperations<CustomerUser>, IEntityDeleteOperations<CustomerUser>, IEntityPatchOperations<CustomerUser>
    {
        /// <summary>
        /// Gets the current user's directory role collection operations.
        /// </summary>
        ICustomerUserRoleCollection DirectoryRoles { get; }

        /// <summary>
        /// Gets the current user's licenses collection operations.
        /// </summary>
        ICustomerUserLicenseCollection Licenses { get; }

        /// <summary>
        /// Gets the current user's license updates operations.
        /// </summary>
        ICustomerUserLicenseUpdates LicenseUpdates { get; }
    }
}