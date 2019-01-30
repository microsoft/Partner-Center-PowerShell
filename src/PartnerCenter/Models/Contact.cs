// -----------------------------------------------------------------------
// <copyright file="Contact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models
{
    /// <summary>
    /// Represents contact information.
    /// </summary>
    public sealed class Contact
    {
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}