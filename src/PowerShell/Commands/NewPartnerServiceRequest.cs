// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Management.Automation;
    using Models.Authentication;
    using Models.ServiceRequests;
    using PartnerCenter.Models.ServiceRequests;
    using Properties;

    [Cmdlet(VerbsCommon.New, "PartnerServiceRequest", SupportsShouldProcess = true), OutputType(typeof(PSServiceRequest))]
    public class NewPartnerServiceRequest : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or sets the locale of the organization creating the service request.
        /// </summary>
        [Parameter(HelpMessage = "The locale of the organization creating the service request.", Mandatory = false)]
        public string AgentLocale { get; set; }

        /// <summary>
        /// Gets or sets the description for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The description for the service request.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the severity for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The severity for the service request.", Mandatory = true)]
        [ValidateSet(nameof(ServiceRequestSeverity.Critical), nameof(ServiceRequestSeverity.Minimal), nameof(ServiceRequestSeverity.Moderate))]
        public ServiceRequestSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the support topic identifier for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The support topic identifier for the service request.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SupportTopicId { get; set; }

        /// <summary>
        /// Gets or sets the title for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The title for the service request.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Title { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ServiceRequest request;
            string agentLocale;

            if (ShouldProcess(Resources.NewPartnerServiceRequestWhatIf))
            {
                agentLocale = string.IsNullOrEmpty(AgentLocale) ? PartnerSession.Instance.Context.Locale : AgentLocale;

                request = new ServiceRequest
                {
                    Description = Description,
                    Severity = Severity,
                    SupportTopicId = SupportTopicId,
                    Title = Title
                };

                request = Partner.ServiceRequests.CreateAsync(request, agentLocale).GetAwaiter().GetResult();

                WriteObject(new PSServiceRequest(request));
            }
        }
    }
}