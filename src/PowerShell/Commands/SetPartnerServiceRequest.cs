// -----------------------------------------------------------------------
// <copyright file="SetPartnerServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using Models.ServiceRequests;
    using PartnerCenter.Models.ServiceRequests;
    using Profile;
    using Properties;

    [Cmdlet(VerbsCommon.Set, "PartnerServiceRequest", SupportsShouldProcess = true), OutputType(typeof(PSServiceRequest))]
    public class SetPartnerServiceRequest : PartnerPSCmdlet
    {
        /// <summary>
        /// Gets or set the text of the new note that will be added to the service request.
        /// </summary>
        [Parameter(HelpMessage = "The text of the new note that will be added to the service request.", Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string NewNote { get; set; }

        /// <summary>
        /// Gets or sets the required service request identifier.
        /// </summary>
        [Parameter(HelpMessage = "The identifier for the service request.", Mandatory = true, Position = 0)]
        [ValidateNotNullOrEmpty]
        public string ServiceRequestId { get; set; }

        /// <summary>
        /// Gets or sets the status for the service request.
        /// </summary>
        [Parameter(HelpMessage = "The status for the service request.", Mandatory = false)]
        [ValidateSet(nameof(ServiceRequestStatus.AttentionNeeded), nameof(ServiceRequestStatus.Closed), nameof(ServiceRequestStatus.Open))]
        public ServiceRequestStatus? Status { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ServiceRequest request;

            if (ShouldProcess(string.Format(CultureInfo.CurrentCulture, Resources.SetPartnerServiceRequestWhatIf, ServiceRequestId)))
            {
                request = new ServiceRequest();

                if (!string.IsNullOrEmpty(NewNote))
                {
                    request.NewNote = new ServiceRequestNote
                    {
                        CreatedByName = PartnerSession.Instance.Context.Account.Properties[AzureAccountPropertyType.UserIdentifier],
                        CreatedDate = DateTime.UtcNow,
                        Text = NewNote
                    };
                }

                if (Status.HasValue)
                {
                    request.Status = Status.Value;
                }

                request = Partner.ServiceRequests[ServiceRequestId].Patch(request);

                WriteObject(new PSServiceRequest(request));
            }
        }
    }
}