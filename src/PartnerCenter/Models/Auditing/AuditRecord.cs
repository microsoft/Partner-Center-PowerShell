// -----------------------------------------------------------------------
// <copyright file="AuditRecord.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Models.Auditing
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Represents a record of operation performed by a partner user or application.
    /// </summary>
    public sealed class AuditRecord : ResourceBase
    {
        /// <summary>
        /// Gets or sets the identifier of the application invoking the operation.
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of customer in whose context operation was performed.
        /// </summary>
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the name of customer in whose context operation was performed.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the dictionary which holds additional data that is customized to the operation performed.
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> CustomizedData { get; set; }

        /// <summary>
        /// Gets or sets a unique identifier for the audit record.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the dateTime when the operation was performed.
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the operation that is audited.
        /// </summary>
        public OperationStatus OperationStatus { get; set; }

        /// <summary>
        /// Gets or sets the type of the operation being performed.
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the correlation identifier associated with the initial operation that created this audit record.
        /// </summary>
        public string OriginalCorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the partner.
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or sets the new value of the resource.
        /// </summary>
        public string ResourceNewValue { get; set; }

        /// <summary>
        /// Gets or sets the old value of the resource.
        /// </summary>
        public string ResourceOldValue { get; set; }

        /// <summary>
        /// Gets or sets the  type of the resource acted upon by the operation.
        /// </summary>
        public ResourceType ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the user who performed the operation.
        /// </summary>
        /// <remarks>
        /// This could be in the context of a 3rd party or 1st party application.
        /// </remarks>
        public string UserPrincipalName { get; set; }

        /// <summary>
        /// Handles errors with deserializing the enum values.
        /// </summary>
        /// <param name="context">The streaming context.</param>
        /// <param name="errorContext">The error context.</param>
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            if (string.Equals(errorContext.Member.ToString(), nameof(ResourceType), StringComparison.OrdinalIgnoreCase))
            {
                (errorContext.OriginalObject as AuditRecord).ResourceType = ResourceType.Undefined;
                errorContext.Handled = true;
            }
            else if (string.Equals(errorContext.Member.ToString(), nameof(OperationType), StringComparison.OrdinalIgnoreCase))
            {
                (errorContext.OriginalObject as AuditRecord).OperationType = OperationType.Undefined;
                errorContext.Handled = true;
            }
        }
    }
}