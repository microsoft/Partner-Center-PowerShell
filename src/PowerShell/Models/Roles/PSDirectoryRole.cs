// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Roles
{
    using Extensions;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// This resource represents the directory roles for a customer.
    /// </summary>
    public sealed class PSDirectoryRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSDirectoryRole" /> class.
        /// </summary>
        public PSDirectoryRole()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSDirectoryRole" /> class.
        /// </summary>
        /// <param name="role">The base role for this instance.</param>
        public PSDirectoryRole(DirectoryRole role)
        {
            this.CopyFrom(role);
        }

        /// <summary>
        /// Converts an instance of <see cref="DirectoryRole" /> to an instance of <see cref="PSDirectoryRole" />.
        /// </summary>
        /// <param name="role">An instance of <see cref="DirectoryRole" /> that will serve as the base for the new instnace of <see cref="PSDirectoryRole" />.</param>
        public static implicit operator PSDirectoryRole(DirectoryRole role)
        {
            if (role == null)
            {
                return null;
            }

            return new PSDirectoryRole(role);
        }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Converts an instance of <see cref="DirectoryRole" /> to an instance of <see cref="PSDirectoryRole" />.
        /// </summary>
        /// <param name="role">An instance of <see cref="DirectoryRole" /> that will serve as the base for the new instance of <see cref="PSDirectoryRole" />.</param>
        public static PSDirectoryRole ToPSDirectoryRole(DirectoryRole role)
        {
            if (role == null)
            {
                return null;
            }

            return new PSDirectoryRole(role);
        }
    }
}