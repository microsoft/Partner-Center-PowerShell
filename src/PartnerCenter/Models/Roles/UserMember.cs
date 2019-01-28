// -----------------------------------------------------------------------
// <copyright file="UserMember.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Roles
{
    /// <summary>
    /// Represents a user role member.
    /// </summary>
    public sealed class UserMember : ResourceBase
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the member.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the user principal.
        /// </summary>
        public string UserPrincipalName { get; set; }
    }
}