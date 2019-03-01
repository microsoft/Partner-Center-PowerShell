// -----------------------------------------------------------------------
// <copyright file="AuditRecordCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Auditing
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Auditing;
    using Models.Query;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the operations that can be performed on a partner's audit records.
    /// </summary>
    internal class AuditRecordCollectionOperations : BasePartnerComponent<string>, IAuditRecordsCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditRecordsCollection" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        public AuditRecordCollectionOperations(IPartner rootPartnerOperations)
          : base(rootPartnerOperations, null)
        {
        }

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
        public async Task<SeekBasedResourceCollection<AuditRecord>> QueryAsync(
            DateTime startDate,
            DateTime? endDate = null,
            IQuery query = null,
            CancellationToken cancellationToken = default)
        {

            if (query != null && query.Type != QueryType.Indexed && query.Type != QueryType.Simple)
            {
                throw new ArgumentException("This type of query is not supported.");
            }

            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Parameters.StartDate,
                    startDate.ToString(CultureInfo.InvariantCulture)
                }
            };

            if (endDate != null)
            {
                parameters.Add(
                    PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Parameters.EndDate,
                    endDate.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (query != null)
            {
                if (query.Type == QueryType.Indexed)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Parameters.Size,
                        query.PageSize.ToString(CultureInfo.InvariantCulture));
                }

                if (query.Filter != null)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Parameters.Filter,
                        JsonConvert.SerializeObject(query.Filter));
                }

                if (query.Token != null)
                {
                    parameters.Add(
                        PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Parameters.ContinuationToken,
                        query.Token.ToString());
                }
            }

            return await Partner.ServiceClient.GetAsync<SeekBasedResourceCollection<AuditRecord>>(
                new Uri(
                    $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAuditRecordsRequest.Path}",
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }
    }
}