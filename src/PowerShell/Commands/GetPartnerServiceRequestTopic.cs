// -----------------------------------------------------------------------
// <copyright file="GetPartnerServiceRequestTopic.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

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
        public override void ExecuteCmdlet() { GetSupportTopics(SupportTopicId); }

        /// <summary>
        /// Gets the specified support topic.
        /// </summary>
        /// <param name="topicId">Identifier for the customer.</param>
        private void GetSupportTopics(string topicId)
        {
            ResourceCollection<SupportTopic> topics;
            IEnumerable<SupportTopic> results;

            try
            {
                topics = Partner.ServiceRequests.SupportTopics.Get();

                if (topics.TotalCount > 0)
                {
                    results = topics.Items;

                    if (!string.IsNullOrEmpty(topicId))
                        results = results.Where(t => t.Id.ToString(CultureInfo.CurrentCulture) == topicId);

                    WriteObject(results.Select(t => new PSSupportTopic(t)), true);
                }
            }
            finally
            {
                topics = null;
                results = null;
            }
        }
    }
}