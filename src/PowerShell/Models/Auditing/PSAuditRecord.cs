// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Models.Auditing
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using PartnerCenter.Models.Auditing;

    /// <summary>
    /// Represents a record of operation performed by a partner user or application
    /// </summary>
    public sealed class PSAuditRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSAuditRecord" /> class.
        /// </summary>
        public PSAuditRecord()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSAuditRecord" /> class.
        /// </summary>
        /// <param name="auditRecord">The base audit record for this instance.</param>
        public PSAuditRecord(AuditRecord auditRecord)
        {
            this.CopyFrom(auditRecord);
        }

        /// <summary>
        /// Gets or sets a unique id for the audit record.
        /// </summary>
        public string AuditRecordId { get; set; }

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
        /// Gets or sets the type of the operation being performed.
        /// </summary>
        public OperationType OperationType { get; set; }

        /// <summary>
        /// Gets or sets the correlation identifier associated with the initial operation that created this audit record.
        /// </summary>
        public string OriginalCorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the dateTime when the operation was performed.
        /// </summary>
        public DateTime OperationDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the operation that is audited.
        /// </summary>
        public OperationStatus OperationStatus { get; set; }

        /// <summary>
        /// Gets or sets the partner identifier.
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
        /// Gets or sets the type of the resource acted upon by the operation.
        /// </summary>
        public ResourceType ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the user principal name of the user that performed the operation.
        /// </summary>
        public string UserPrincipalName { get; set; }
    }
}