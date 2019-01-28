// -----------------------------------------------------------------------
// <copyright file="ServiceRequestContact.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    /// <summary>
    /// Represents a service request contact profile.
    /// </summary>
    public sealed class ServiceRequestContact
    {
        /// <summary>
        /// Gets or sets the contact identifier.
        /// </summary>
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the organization profile.
        /// </summary>
        public ServiceRequestOrganization Organization { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}