// -----------------------------------------------------------------------
// <copyright file="IAzureUtilizationCollection.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.Utilization
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using Models.Query;
    using Models.Utilizations;

    /// <summary>
    /// Groups behavior related to Azure subscription utilization records.
    /// </summary>
    public interface IAzureUtilizationCollection : IPartnerComponent<Tuple<string, string>>
    {
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
        ResourceCollection<AzureUtilizationRecord> Query(
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            AzureUtilizationGranularity granularity = AzureUtilizationGranularity.Daily,
            bool showDetails = true,
            int size = 1000, 
            CancellationToken cancellationToken = default(CancellationToken));

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
        Task<ResourceCollection<AzureUtilizationRecord>> QueryAsync(
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            AzureUtilizationGranularity granularity = AzureUtilizationGranularity.Daily,
            bool showDetails = true,
            int size = 1000,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Seeks pages of of utilization for resources that belong to an Azure subscription owned by a customer of the partner.
        /// </summary>
        /// <param name="continuationToken">The continuation token from the previous results.</param>
        /// <param name="seekOperation">The seek operation to perform. Next is only supported.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The next page of utilization records.</returns>
        ResourceCollection<AzureUtilizationRecord> Seek(string continuationToken, SeekOperation seekOperation = SeekOperation.Next, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Asynchronously seeks pages of utilization for resources that belong to an Azure subscription owned by a customer of the partner.
        /// </summary>
        /// <param name="continuationToken">The continuation token from the previous results.</param>
        /// <param name="seekOperation">The seek operation to perform. Next is only supported.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A task that returns the next page of utilization records.</returns>
        Task<ResourceCollection<AzureUtilizationRecord>> SeekAsync(string continuationToken, SeekOperation seekOperation = SeekOperation.Next, CancellationToken cancellationToken = default(CancellationToken));
    }
}