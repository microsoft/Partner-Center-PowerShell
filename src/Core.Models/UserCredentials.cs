// -----------------------------------------------------------------------
// <copyright file="UserCredentials.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Core.Models
{
    /// <summary>
    /// Holds the credentials needed for the user to access their services.
    /// </summary>
    public sealed class UserCredentials
    {
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string UserName { get; set; }
    }
}