// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Enumerators;
    using Models.Utilizations;
    using PartnerCenter.Models;
    using PartnerCenter.Models.Utilizations;

    /// <summary>
    /// Cmdlet used to obtain Azure utilization records for the specified subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerCustomerSubscriptionUtilization"), OutputType(typeof(PSAzureUtilizationRecord))]
    public class GetPartnerCustomerSubscriptionUtilization : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the identifier of the customer that owns the subscription.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the customer.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the end date (in UTC) of the usages to filter.
        /// </summary>
        [Parameter(HelpMessage = "The end date (in UTC) of the usages to filter.", Mandatory = false)]
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the resource usage time granularity. Can either be daily or hourly. The default value is daily.
        /// </summary>
        [Parameter(HelpMessage = "The resource usage time granularity. Can either be daily or hourly. The default value is daily.", Mandatory = false)]
        public AzureUtilizationGranularity? Granularity { get; set; }

        /// <summary>
        /// Gets or sets the page size.
        /// </summary>
        [Parameter(HelpMessage = "The number of records returned with a single request to the partner service.", Mandatory = false)]
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether or not utilization records will be aggregated on the resource level.
        /// </summary>
        /// <remarks>
        /// If set to true, the utilization records will be split by the resource instance
        /// levels. If set to false, the utilization records will be aggregated on the resource level. 
        /// </remarks>
        [Parameter(HelpMessage = "A flag that incicates whether or not utilization records will be aggregated on the resource level.", Mandatory = true)]
        [ValidateNotNull]
        public SwitchParameter ShowDetails { get; set; }

        /// <summary>
        /// Gets or sets the start date (in UTC) of the usages to filter.
        /// </summary>
        [Parameter(HelpMessage = "The start date (in UTC) of the usages to filter.", Mandatory = true)]
        [ValidateNotNull]
        public DateTimeOffset StartDate { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the Azure subscription.
        /// </summary>
        [Parameter(HelpMessage = "The identifier of the subscription.", Mandatory = true)]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            List<PSAzureUtilizationRecord> records = Task.Run(() => RunAsync()).ConfigureAwait(false).GetAwaiter().GetResult();

            WriteObject(records, true);
        }

        public async Task<List<PSAzureUtilizationRecord>> RunAsync()
        {
            IResourceCollectionEnumerator<ResourceCollection<AzureUtilizationRecord>> enumerator;
            List<PSAzureUtilizationRecord> records = new List<PSAzureUtilizationRecord>();
            ResourceCollection<AzureUtilizationRecord> utilizationRecords;

            utilizationRecords = await Partner.Customers[CustomerId]
                .Subscriptions[SubscriptionId]
                .Utilization.Azure.QueryAsync(
                    StartDate,
                    EndDate ?? DateTimeOffset.UtcNow,
                    Granularity ?? AzureUtilizationGranularity.Daily,
                    !ShowDetails.IsPresent || ShowDetails.ToBool(),
                    PageSize == null ? 1000 : PageSize.Value).ConfigureAwait(false);

            if (utilizationRecords?.TotalCount > 0)
            {
                enumerator = Partner.Enumerators.Utilization.Azure.Create(utilizationRecords);

                while (enumerator.HasValue)
                {
                    records.AddRange(enumerator.Current.Items.Select(r => new PSAzureUtilizationRecord(r)));
                    await enumerator.NextAsync().ConfigureAwait(false);
                }
            }

            return records;
        }
    }
}