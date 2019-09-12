// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Roles
{
    using Extensions;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Represents a role at the partner level.
    /// </summary>
    public sealed class PSRole
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSRole" /> class.
        /// </summary>
        public PSRole()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSRole" /> class.
        /// </summary>
        /// <param name="role">The base role for this instance.</param>
        public PSRole(Role role)
        {
            this.CopyFrom(role, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the role.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="Role" /> to an instance of <see cref="PSRole" />. 
        /// </summary>
        /// <param name="role">The role being cloned.</param>
        private void CloneAdditionalOperations(Role role)
        {
            RoleId = role.Id;
        }
    }
}