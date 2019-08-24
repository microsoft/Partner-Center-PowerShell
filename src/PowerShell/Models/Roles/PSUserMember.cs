// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Roles
{
    using Extensions;
    using PartnerCenter.Models.Roles;

    /// <summary>
    /// Represents a user role member.
    /// </summary>
    public sealed class PSUserMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSUserMember" /> class.
        /// </summary>
        public PSUserMember()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSUserMember" /> class.
        /// </summary>
        /// <param name="userMember">The base role for this instance.</param>
        public PSUserMember(UserMember userMember)
        {
            this.CopyFrom(userMember, CloneAdditionalOperations);
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the member.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the user principal.
        /// </summary>
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Additional operations to be performed when cloning an instance of <see cref="UserMember" /> to an instance of <see cref="PSUserMember" />. 
        /// </summary>
        /// <param name="userMember">The user member being cloned.</param>
        private void CloneAdditionalOperations(UserMember userMember)
        {
            UserId = userMember.Id;
        }
    }
}