// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Models.ServiceRequests;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ServiceRequests;

    /// <summary>
    /// Get a service request, or a list of service requests, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerServiceRequestTopic"), OutputType(typeof(PSSupportTopic))]
    public class GetPartnerServiceRequestTopic : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the support topic identifier
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The identifier of the support topic.")]
        public string SupportTopicId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ResourceCollection<SupportTopic> topics;
            IEnumerable<SupportTopic> results;

            topics = Partner.ServiceRequests.SupportTopics.GetAsync().GetAwaiter().GetResult();

            if (topics.TotalCount > 0)
            {
                results = topics.Items;

                if (!string.IsNullOrEmpty(SupportTopicId))
                {
                    results = results.Where(t => t.Id.ToString(CultureInfo.CurrentCulture) == SupportTopicId);
                }

                WriteObject(results.Select(t => new PSSupportTopic(t)), true);
            }
        }
    }
}