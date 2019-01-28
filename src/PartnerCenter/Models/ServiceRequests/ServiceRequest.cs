// -----------------------------------------------------------------------
// <copyright file="ServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceRequests
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a request ticket raised against a service.
    /// </summary>
    public sealed class ServiceRequest : ResourceBase
    {
        /// <summary>
        /// Gets or sets the country code in ISO 2 alpha format.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the time the service request was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the service request description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the ticket last closed date.
        /// </summary>
        public DateTime LastClosedDate { get; set; }

        /// <summary>
        /// Gets or sets the ticket last modified date.
        /// </summary>
        public DateTime LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the last updated by contact for changes to the service request.
        /// </summary>
        public ServiceRequestContact LastUpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a new note that can be added to an existing service request.
        /// </summary>
        public ServiceRequestNote NewNote { get; set; }

        /// <summary>
        /// Gets or sets a collection of notes associated with the service request.
        /// </summary>
        public IEnumerable<ServiceRequestNote> Notes { get; set; }

        /// <summary>
        /// Gets or sets the organization for whom the service request is being created.
        /// </summary>
        public ServiceRequestOrganization Organization { get; set; }

        /// <summary>
        /// Gets or sets the primary contact on the service request.
        /// </summary>
        public ServiceRequestContact PrimaryContact { get; set; }

        /// <summary>
        /// Gets or sets the affected product identifier.
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the affected product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the severity.
        /// </summary>
        public ServiceRequestSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the service request status.
        /// </summary>
        public ServiceRequestStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the support topic for the service request.
        /// </summary>
        public string SupportTopicId { get; set; }

        /// <summary>
        /// Gets or sets the name of the support topic related to the service request.
        /// </summary>
        public string SupportTopicName { get; set; }

        /// <summary>
        /// Gets or sets the service request title.
        /// </summary>
        public string Title { get; set; }
    }
}
