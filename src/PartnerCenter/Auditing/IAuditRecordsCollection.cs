// -----------------------------------------------------------------------
// <copyright file="IAuditRecordsCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Auditing
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Auditing;
    using Models.Query;

    /// <summary>
    /// Represents the operations that can be done on partners audit collection.
    /// </summary>
    public interface IAuditRecordsCollection : IPartnerComponent<string>
    {
        /// <summary>
        /// Queries audit records associated to the partner.
        /// The following queries are supported:
        /// - Specify the number of audit record to return.
        /// - Filter the result with a customer name.
        /// </summary>
        /// <param name="startDate">The start date of the audit record logs.</param>
        /// <param name="endDate">The end date of the audit record logs.</param>
        /// <param name="query">The query.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The audit records that match the given query.</returns>
        Task<SeekBasedResourceCollection<AuditRecord>> QueryAsync(
            DateTime startDate,
            DateTime? endDate = null,
            IQuery query = null,
            CancellationToken cancellationToken = default);
    }
}