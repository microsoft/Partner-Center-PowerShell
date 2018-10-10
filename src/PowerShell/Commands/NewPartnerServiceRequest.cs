﻿// -----------------------------------------------------------------------
// <copyright file="NewPartnerServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using Models.ServiceRequests;
    using PartnerCenter.Models.ServiceRequests;
    using Profile;
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
        [Parameter(HelpMessage = "The descripion for the service reuqest.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the severity for the service reuqest.
        /// </summary>
        [Parameter(HelpMessage = "The severity for the service reuqest.", Mandatory = true)]
        [ValidateSet(nameof(ServiceRequestSeverity.Critical), nameof(ServiceRequestSeverity.Minimal), nameof(ServiceRequestSeverity.Moderate))]
        public ServiceRequestSeverity Severity { get; set; }

        /// <summary>
        /// Gets or sets the support topic identifier for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The support topic identifier for the service reuqest.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SupportTopicId { get; set; }

        /// <summary>
        /// Gets or sets the title for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The title for the service reuqest.", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Title { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ServiceRequest request;
            string agentLocale;

            try
            {
                if (ShouldProcess(Resources.NewPartnerServiceRequestWhatIf))
                {
                    agentLocale = string.IsNullOrEmpty(AgentLocale) ? PartnerSession.Instance.Context.Locale : AgentLocale;

                    if (!IsValidCulture(agentLocale))
                    {
                        throw new PSInvalidOperationException(string.Format(CultureInfo.CurrentCulture, "{0} is an invalid culture.", agentLocale));
                    }

                    request = new ServiceRequest
                    {
                        Description = Description,
                        Severity = Severity,
                        SupportTopicId = SupportTopicId,
                        Title = Title
                    };

                    request = Partner.ServiceRequests.Create(request, agentLocale);

                    WriteObject(new PSServiceRequest(request));
                }
            }
            finally
            {
                request = null;
            }
        }

        private static bool IsValidCulture(string locale)
        {
            CultureInfo[] cultures;
            CultureInfo culture;

            try
            {
                cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
                culture = cultures.Where(x => x.Name.Equals(locale, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

                return culture != null;
            }
            finally
            {
                culture = null;
                cultures = null;
            }
        }
    }
}