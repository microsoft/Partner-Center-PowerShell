// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Enumerators;
    using Models.Auditing;
    using Models.Authentication;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Auditing;
    using Properties;
    using RequestContext;

    /// <summary>
    /// Cmdlet that retrieves audit records from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerAuditRecord")]
    [OutputType(typeof(PSAuditRecord))]
    public class GetPartnerAuditRecord : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the end date porition of the query.
        /// </summary>
        [Parameter(HelpMessage = "The end date of the audit record logs.", Mandatory = false)]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the start date porition of the query.
        /// </summary>
        [Parameter(HelpMessage = "The start date of the audit record logs.", Mandatory = false)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                DateTime endDate;
                IResourceCollectionEnumerator<SeekBasedResourceCollection<AuditRecord>> enumerator;
                List<PSAuditRecord> records;
                SeekBasedResourceCollection<AuditRecord> auditRecords;

                endDate = EndDate ?? DateTime.Now;

                if ((endDate - StartDate).Days >= 90)
                {
                    throw new PSInvalidOperationException(Resources.AuditRecordDateError);
                }

                records = new List<PSAuditRecord>();

                foreach (DateTime date in ChunkDate(StartDate, endDate, 30))
                {
                    auditRecords = await partner.AuditRecords.QueryAsync(date, null, null, CancellationToken).ConfigureAwait(false);
                    enumerator = partner.Enumerators.AuditRecords.Create(auditRecords);

                    while (enumerator.HasValue)
                    {
                        records.AddRange(enumerator.Current.Items.Select(r => new PSAuditRecord(r)));
                        await enumerator.NextAsync(RequestContextFactory.Create(CorrelationId), CancellationToken).ConfigureAwait(false);
                    }
                }

                WriteObject(records, true);
            }, true);
        }

        private static IEnumerable<DateTime> ChunkDate(DateTime startDate, DateTime endDate, int size)
        {
            while (startDate < endDate)
            {
                yield return startDate;

                startDate = startDate.AddDays(size);
            }
        }
    }
}