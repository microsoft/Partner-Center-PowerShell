// -----------------------------------------------------------------------
// <copyright file="UserLicenseError.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Subscriptions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the user and the services that had errors during license transfer.
    /// </summary>
    public sealed class UserLicenseError
    {
        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the list of errors that occurred during license transfer.
        /// </summary>
        public IEnumerable<ApiFault> Errors { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user object identifier.
        /// </summary>
        public Guid UserObjectId { get; set; }
    }
}