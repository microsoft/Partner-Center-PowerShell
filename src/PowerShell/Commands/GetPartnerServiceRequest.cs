// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Extensions;
    using Models.ServiceRequests;
    using PartnerCenter.Enumerators;
    using PartnerCenter.Models;
    using PartnerCenter.Models.ServiceRequests;

    /// <summary>
    /// Get a service request, or a list of service requests, from Partner Center.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "PartnerServiceRequest", DefaultParameterSetName = "ByStatus"), OutputType(typeof(PSServiceRequest))]
    public class GetPartnerServiceRequest : PartnerPSCmdlet
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
            if (!string.IsNullOrEmpty(CustomerId))
            {
                if (!string.IsNullOrEmpty(RequestId))
                {
                    GetCustomerServiceRequest(CustomerId, RequestId);
                }
                else
                {
                    GetCustomerServiceRequests(CustomerId, Status, Severity);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(RequestId))
                {
                    GetServiceRequest(RequestId);
                }
                else
                {
                    GetServiceRequests(Status, Severity);
                }
            }
        }

        /// <summary>
        /// Gets the specified service request for a customer.
        /// </summary>
        /// <param name="customerId">The identifier for the customer.</param>
        /// <param name="requestId">The identifier for the service request.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="requestId"/> is empty or null.
        /// </exception>
        private void GetCustomerServiceRequest(string customerId, string requestId)
        {
            ServiceRequest request;

            customerId.AssertNotEmpty(nameof(customerId));
            requestId.AssertNotEmpty(nameof(requestId));


            request = Partner.Customers.ById(customerId).ServiceRequests.ById(requestId).GetAsync().GetAwaiter().GetResult();

            if (request != null)
            {
                WriteObject(new PSServiceRequest(request));
            }

        }

        /// <summary>
        /// Gets a list of service requests for a customer.
        /// </summary>
        /// <param name="customerId">The identifier of the customer.</param>
        /// <param name="status">The status of the service request.</param>
        /// <param name="severity">The severity of the service request.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetCustomerServiceRequests(string customerId, ServiceRequestStatus? status, ServiceRequestSeverity? severity)
        {
            ResourceCollection<ServiceRequest> requests;

            customerId.AssertNotEmpty(nameof(customerId));

            requests = Partner.Customers.ById(customerId).ServiceRequests.GetAsync().GetAwaiter().GetResult();

            if (requests.TotalCount > 0)
            {
                HandleOutput(requests, severity, status);
            }
        }

        /// <summary>
        /// Gets the specified service request for a partner.
        /// </summary>
        /// <param name="requestId">Identifier for the service request.</param>
        /// <exception cref="ArgumentException">
        /// <paramref name="requestId"/> is empty or null.
        /// </exception>
        private void GetServiceRequest(string requestId)
        {
            ServiceRequest request;

            requestId.AssertNotEmpty(nameof(requestId));

            request = Partner.ServiceRequests.ById(requestId).GetAsync().GetAwaiter().GetResult();

            if (request != null)
            {
                WriteObject(new PSServiceRequest(request));
            }

        }

        /// <summary>
        /// Gets a list of service requests for a partner.
        /// </summary>
        /// <param name="status">Identifier for the service request.</param>
        /// <param name="severity">Identifier for the service request.</param>
        private void GetServiceRequests(ServiceRequestStatus? status, ServiceRequestSeverity? severity)
        {
            ResourceCollection<ServiceRequest> requests;

            requests = Partner.ServiceRequests.GetAsync().GetAwaiter().GetResult();

            if (requests.TotalCount > 0)
            {
                HandleOutput(requests, severity, status);
            }
        }

        private void HandleOutput(ResourceCollection<ServiceRequest> requests, ServiceRequestSeverity? severity, ServiceRequestStatus? status)
        {
            IResourceCollectionEnumerator<ResourceCollection<ServiceRequest>> enumerator;
            List<ServiceRequest> serviceRequests;

            enumerator = Partner.Enumerators.ServiceRequests.Create(requests);
            serviceRequests = new List<ServiceRequest>();

            while (enumerator.HasValue)
            {
                serviceRequests.AddRange(enumerator.Current.Items);
                enumerator.NextAsync().GetAwaiter().GetResult();
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