// -----------------------------------------------------------------------
// <copyright file="User.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Users
{
    using System;

    /// <summary>
    /// Represents a user object used as a contract for partner user and customer user operations.
    /// </summary>
    public class User : ResourceBaseWithLinks<StandardResourceLinks>
    {
        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user object identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the last directory sync time for the user.
        /// </summary>
        public DateTime? LastDirectorySyncTime { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password profile.
        /// </summary>
        public PasswordProfile PasswordProfile { get; set; }

        /// <summary>
        /// Gets or sets the deleted time for the inactive user.
        /// </summary>
        public DateTime? SoftDeletionTime { get; set; }

        /// <summary>
        /// Gets or sets the state of the user, for the deleted user this is "Inactive" and for the normal user it is "Active".
        /// </summary>
        public UserState State { get; set; }

        /// <summary>
        /// Gets or sets user domain type.
        /// </summary>
        public UserDomainType UserDomainType { get; set; }

        /// <summary>
        /// Gets or sets the name of the user principal.
        /// </summary>
        public string UserPrincipalName { get; set; }
    }
}