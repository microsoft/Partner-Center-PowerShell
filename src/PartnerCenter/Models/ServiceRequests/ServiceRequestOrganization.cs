// -----------------------------------------------------------------------
// <copyright file="ServiceRequestOrganization.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    /// <summary>
    /// Holds the organization information that a service request pertains to.
    /// </summary>
    public sealed class ServiceRequestOrganization
    {
        /// <summary>
        /// Gets or sets the organization identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the organization.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tenant phone number.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}