// -----------------------------------------------------------------------
// <copyright file="AzureUtilizationCollectionOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Utilization
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models;
    using Models.JsonConverters;
    using Models.Query;
    using Models.Utilizations;

    /// <summary>
    /// Groups behavior related to Azure subscription utilization records.
    /// </summary>
    internal class AzureUtilizationCollectionOperations : BasePartnerComponent<Tuple<string, string>>, IAzureUtilizationCollection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AzureUtilizationCollectionOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <param name="subscriptionId">Identifier for the subscription.</param>
        public AzureUtilizationCollectionOperations(IPartner rootPartnerOperations, string customerId, string subscriptionId)
            : base(rootPartnerOperations, new Tuple<string, string>(customerId, subscriptionId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            subscriptionId.AssertNotEmpty(nameof(subscriptionId));
        }

        /// <summary>
        /// Retrieves utilization records for the Azure subscription.
        /// </summary>
        /// <param name="startTime">The starting time of when the utilization was metered in the billing system.</param>
        /// <param name="endTime">The ending time of when the utilization was metered in the billing system.</param>
        /// <param name="granularity">The resource usage time granularity. Can either be daily or hourly. Default is daily.</param>
        /// <param name="showDetails">If set to true, the utilization records will be split by the resource instance levels. If set to false, the utilization records
        /// will be aggregated on the resource level. Default is true.</param>
        /// <param name="size">An optional maximum number of records to return. Default is 1000. The returned resource collection will specify a next link in case there
        /// were more utilization records available.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The Azure resource utilization for the subscription.</returns>
        public ResourceCollection<AzureUtilizationRecord> Query(
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            AzureUtilizationGranularity granularity = AzureUtilizationGranularity.Daily,
            bool showDetails = true,
            int size = 1000, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(
                () => QueryAsync(
                    startTime,
                    endTime,
                    granularity,
                    showDetails,
                    size, 
                    cancellationToken));
        }

        /// <summary>
        /// Retrieves utilization records for the Azure subscription.
        /// </summary>
        /// <param name="startTime">The starting time of when the utilization was metered in the billing system.</param>
        /// <param name="endTime">The ending time of when the utilization was metered in the billing system.</param>
        /// <param name="granularity">The resource usage time granularity. Can either be daily or hourly. Default is daily.</param>
        /// <param name="showDetails">If set to true, the utilization records will be split by the resource instance levels. If set to false, the utilization records
        /// will be aggregated on the resource level. Default is true.</param>
        /// <param name="size">An optional maximum number of records to return. Default is 1000. The returned resource collection will specify a next link in case there
        /// were more utilization records available.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The Azure resource utilization for the subscription.</returns>
        public async Task<ResourceCollection<AzureUtilizationRecord>> QueryAsync(
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            AzureUtilizationGranularity granularity = AzureUtilizationGranularity.Daily,
            bool showDetails = true,
            int size = 1000,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            IDictionary<string, string> parameters;

            parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Parameters.EndTime,
                    endTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Parameters.Granularity,
                    granularity.ToString()
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Parameters.ShowDetails,
                    showDetails.ToString(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Parameters.Size,
                    size.ToString(CultureInfo.InvariantCulture)
                },
                {
                    PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Parameters.StartTime,
                    startTime.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<AzureUtilizationRecord>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetAzureUtilizationRecords.Path}",
                        Context.Item1,
                        Context.Item2),
                    UriKind.Relative),
                parameters,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Seeks pages of of utilization for resources that belong to an Azure subscription owned by a customer of the partner.
        /// </summary>
        /// <param name="continuationToken">The continuation token from the previous results.</param>
        /// <param name="seekOperation">The seek operation to perform. Next is only supported.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The next page of utilization records.</returns>
        public ResourceCollection<AzureUtilizationRecord> Seek(string continuationToken, SeekOperation seekOperation = SeekOperation.Next, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => SeekAsync(continuationToken, seekOperation, cancellationToken));
        }

        /// <summary>
        /// Seeks pages of of utilization for resources that belong to an Azure subscription owned by a customer of the partner.
        /// </summary>
        /// <param name="continuationToken">The continuation token from the previous results.</param>
        /// <param name="seekOperation">The seek operation to perform. Next is only supported.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The next page of utilization records.</returns>
        public async Task<ResourceCollection<AzureUtilizationRecord>> SeekAsync(string continuationToken, SeekOperation seekOperation = SeekOperation.Next, CancellationToken cancellationToken = default(CancellationToken))
        {
            continuationToken.AssertNotEmpty(nameof(continuationToken));

            IDictionary<string, string> headers = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.SeekAzureUtilizationRecords.AdditionalHeaders.ContinuationToken,
                    continuationToken
                }
            };

            IDictionary<string, string> parameters = new Dictionary<string, string>
            {
                {
                    PartnerService.Instance.Configuration.Apis.SeekAzureUtilizationRecords.Parameters.SeekOperation,
                    seekOperation.ToString()
                }
            };

            return await Partner.ServiceClient.GetAsync<ResourceCollection<AzureUtilizationRecord>>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.SeekAzureUtilizationRecords.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                headers,
                parameters,
                new ResourceCollectionConverter<AzureUtilizationRecord>(),
                cancellationToken).ConfigureAwait(false);
        }
    }
}