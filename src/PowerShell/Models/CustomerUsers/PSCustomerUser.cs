// -----------------------------------------------------------------------
// <copyright file="PSCustomerUser.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.CustomerUsers
{
    using System;
    using Common;
    using PartnerCenter.Models.Users;

    /// <summary>
    /// Represents a form of customer users.
    /// </summary>
    public sealed class PSCustomerUser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerUser" /> class.
        /// </summary>
        public PSCustomerUser()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSCustomerUser" /> class.
        /// </summary>
        /// <param name="customerUser">The base customer user for this instance.</param>
        public PSCustomerUser(CustomerUser customerUser)
        {
            this.CopyFrom(customerUser, CloneAdditionalOperations);
        }

        /// <summary>
        ///     Gets or sets the user object identifier.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Gets or sets the display name.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     Gets or sets the name of the user principal.
        /// </summary>
        public string UserPrincipalName { get; set; }

        /// <summary>
        ///     Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets user domain type.
        /// </summary>
        public UserDomainType UserDomainType { get; set; }

        /// <summary>
        ///     Gets or sets the state of the user, for the deleted user this is "Inactive" and
        ///     for the normal user it is "Active".
        /// </summary>
        public UserState State { get; set; }

        /// <summary>
        ///     Gets or sets the deleted time for the inactive user.
        /// </summary>
        public DateTime? SoftDeletionTime { get; set; }

        /// <summary>
        ///     Gets or sets the last directory sync time for the user.
        /// </summary>
        public DateTime? LastDirectorySyncTime { get; set; }

        /// <summary>
        /// Addtional operations to be performed when cloning an instance of <see cref="User" /> to an instance of <see cref="PSCustomerUser" />. 
        /// </summary>
        /// <param name="customerUser">The customer user being cloned.</param>
        private void CloneAdditionalOperations(CustomerUser customerUser) => UserId = customerUser.Id;
    }
}