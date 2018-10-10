// -----------------------------------------------------------------------
// <copyright file="GetPartnerCustomerSubscriptionUtilization.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
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
        [Parameter(HelpMessage = "The resource usage time granularity. Can either be daily or hourly. The default value is daily", Mandatory = false)]
        public AzureUtilizationGranularity? Granularity { get; set; }

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
            IResourceCollectionEnumerator<ResourceCollection<AzureUtilizationRecord>> enumerator;
            List<PSAzureUtilizationRecord> records;
            ResourceCollection<AzureUtilizationRecord> utilizationRecords;

            try
            {
                utilizationRecords = Partner.Customers[CustomerId]
                    .Subscriptions[SubscriptionId]
                    .Utilization.Azure.Query(
                        StartDate,
                        EndDate ?? DateTimeOffset.Now,
                        Granularity ?? AzureUtilizationGranularity.Daily,
                        (!ShowDetails.IsPresent) || ShowDetails.ToBool());

                enumerator = Partner.Enumerators.Utilization.Azure.Create(utilizationRecords);

                records = new List<PSAzureUtilizationRecord>();

                while (enumerator.HasValue)
                {
                    records.AddRange(enumerator.Current.Items.Select(r => new PSAzureUtilizationRecord(r)));
                    enumerator.Next();
                }

                WriteObject(records, true);
            }
            finally
            {
                enumerator = null;
                records = null;
                utilizationRecords = null;
            }
        }
    }
}