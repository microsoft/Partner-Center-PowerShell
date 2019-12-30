// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Models.Authentication;
    using Models.ServiceRequests;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ServiceRequests;

    /// <summary>
    /// Get a service request, or a list of service requests, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerServiceRequest", DefaultParameterSetName = "ByStatus")]
    [OutputType(typeof(PSServiceRequest))]
    public class GetPartnerServiceRequest : PartnerAsyncCmdlet
    {
        /// <summary>
        /// Gets or sets the request status
        /// </summary>
        [Parameter(ParameterSetName = "ByStatus", Mandatory = false, HelpMessage = "The status of the support request.")]
        [Parameter(ParameterSetName = "BySeverity", Mandatory = false, HelpMessage = "The status of the support request.")]
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = false, HelpMessage = "The status of the support request.")]
        [ValidateSet(nameof(ServiceRequestStatus.AttentionNeeded), nameof(ServiceRequestStatus.Closed), nameof(ServiceRequestStatus.None), nameof(ServiceRequestStatus.Open))]
        public ServiceRequestStatus? Status { get; set; }

        /// <summary>
        /// Gets or sets the request severity
        /// </summary>
        [Parameter(ParameterSetName = "ByStatus", Mandatory = false, HelpMessage = "The status of the support request.")]
        [Parameter(ParameterSetName = "BySeverity", Mandatory = false, HelpMessage = "The status of the support request.")]
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = false, HelpMessage = "The status of the support request.")]
        [ValidateSet(nameof(ServiceRequestSeverity.Critical), nameof(ServiceRequestSeverity.Minimal), nameof(ServiceRequestSeverity.Moderate), nameof(ServiceRequestSeverity.Unknown))]
        public ServiceRequestSeverity? Severity { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        [Parameter(ParameterSetName = "ByCustomerId", Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [Parameter(ParameterSetName = "ByRequestId", Mandatory = true, HelpMessage = "The identifier of the customer.")]
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled | RegexOptions.IgnoreCase)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the service request identifier
        /// </summary>
        [Parameter(ParameterSetName = "ByRequestId", Mandatory = false, HelpMessage = "The identifier of the service request.")]
        public string RequestId { get; set; }

        /// <summary>
        /// Executes the operations associated with the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            Scheduler.RunTask(async () =>
            {
                IPartner partner = await PartnerSession.Instance.ClientFactory.CreatePartnerOperationsAsync(CorrelationId, CancellationToken).ConfigureAwait(false);

                if (!string.IsNullOrEmpty(CustomerId))
                {
                    if (!string.IsNullOrEmpty(RequestId))
                    {
                        ServiceRequest request = await partner.Customers.ById(CustomerId).ServiceRequests.ById(RequestId).GetAsync(CancellationToken).ConfigureAwait(false);
                        WriteObject(request);
                    }
                    else
                    {
                        ResourceCollection<ServiceRequest> requests = await partner.Customers.ById(CustomerId).ServiceRequests.GetAsync(CancellationToken).ConfigureAwait(false);
                        await HandleOutputAsync(partner, requests, Severity, Status).ConfigureAwait(false);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(RequestId))
                    {
                        ServiceRequest request = await partner.ServiceRequests.ById(RequestId).GetAsync(CancellationToken).ConfigureAwait(false);
                        WriteObject(request);
                    }
                    else
                    {
                        ResourceCollection<ServiceRequest> requests = await partner.ServiceRequests.GetAsync(CancellationToken).ConfigureAwait(false);
                        await HandleOutputAsync(partner, requests, Severity, Status).ConfigureAwait(false);
                    }
                }
            }, true);
        }

        private async Task HandleOutputAsync(IPartner partner, ResourceCollection<ServiceRequest> requests, ServiceRequestSeverity? severity, ServiceRequestStatus? status)
        {
            IResourceCollectionEnumerator<ResourceCollection<ServiceRequest>> enumerator;
            List<ServiceRequest> serviceRequests;

            enumerator = partner.Enumerators.ServiceRequests.Create(requests);
            serviceRequests = new List<ServiceRequest>();

            while (enumerator.HasValue)
            {
                serviceRequests.AddRange(enumerator.Current.Items);
                // TODO - Inject request context here.
                await enumerator.NextAsync(null, CancellationToken).ConfigureAwait(false);
            }

            if (severity.HasValue && status.HasValue)
            {
                WriteObject(serviceRequests.Where(r => r.Severity == severity && r.Status == status).Select(r => new PSServiceRequest(r)), true);
            }
            else if (severity.HasValue)
            {
                WriteObject(serviceRequests.Where(r => r.Severity == severity).Select(r => new PSServiceRequest(r)), true);
            }
            else if (status.HasValue)
            {
                WriteObject(serviceRequests.Where(r => r.Status == status).Select(r => new PSServiceRequest(r)), true);
            }
            else
            {
                WriteObject(serviceRequests.Select(r => new PSServiceRequest(r)), true);
            }

        }
    }
}