// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Models.Authentication;
    using Models.ServiceRequests;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ServiceRequests;

    /// <summary>
    /// Get a service request, or a list of service requests, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerServiceRequestTopic"), OutputType(typeof(PSSupportTopic))]
    public class GetPartnerServiceRequestTopic : PartnerAsyncCmdlet
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
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);
                ResourceCollection<SupportTopic> topics;

                topics = await partner.ServiceRequests.SupportTopics.GetAsync(CancellationToken).ConfigureAwait(false);


                if (!string.IsNullOrEmpty(SupportTopicId))
                {
                    WriteObject(topics.Items.Where(t => t.Id.ToString(CultureInfo.CurrentCulture) == SupportTopicId));
                }
                else
                {
                    WriteObject(topics.Items.Select(t => new PSSupportTopic(t)), true);
                }
            }, true);
        }
    }
}