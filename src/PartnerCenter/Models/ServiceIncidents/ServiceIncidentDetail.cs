// -----------------------------------------------------------------------
// <copyright file="ServiceIncidentDetail.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.ServiceIncidents
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an Office service health incident message.
    /// </summary>
    public sealed class ServiceIncidentDetail
    {
        /// <summary>
        /// Gets or sets the type of action to be followed up with - set only for message center type messages.
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets the affected workload names.
        /// </summary>
        public IEnumerable<string> AffectedWorkloadNames { get; set; }

        /// <summary>
        /// Gets or sets the category of message center - set only for message center type messages.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the incident end time.
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// Gets or sets the incident identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the impacted area.
        /// </summary>
        public string ImpactedArea { get; set; }

        /// <summary>
        /// Gets or sets the affected tenant count.
        /// </summary>
        public int ImpactedCustomers { get; set; }

        /// <summary>
        /// Gets or sets the service health messages.
        /// </summary>
        public IEnumerable<ServiceIncidentHistory> Messages { get; set; }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public MessageType MessageType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an incident is resolved or not.
        /// </summary>
        public bool Resolved { get; set; }

        /// <summary>
        /// Gets or sets the date by which partner is expected to complete an action - set only for message center type messages.
        /// </summary>
        public DateTime RequiredBy { get; set; }

        /// <summary>
        /// Gets or sets the severity of the message - set only for message center type messages.
        /// </summary>
        public ServiceIncidentStatus Severity { get; set; }

        /// <summary>
        /// Gets or sets the incident start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public ServiceIncidentStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the workload name.
        /// </summary>
        public string Workload { get; set; }
    }
}