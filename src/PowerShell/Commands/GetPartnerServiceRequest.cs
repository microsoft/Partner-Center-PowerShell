// -----------------------------------------------------------------------
// <copyright file="GetPartnerServiceRequest.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.PowerShell.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text.RegularExpressions;
    using Common;
    using Models.ServiceRequests;
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
        [ValidatePattern(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", Options = RegexOptions.Compiled)]
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
        /// <param name="customerId">Identifier for the customer.</param>
        /// <param name="requestId">Identifier for the service request.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// or
        /// <paramref name="requestId"/> is empty or null.
        /// </exception>
        private void GetCustomerServiceRequest(string customerId, string requestId)
        {
            ServiceRequest request;

            customerId.AssertNotEmpty(nameof(customerId));
            requestId.AssertNotEmpty(nameof(requestId));

            try
            {
                request = Partner.Customers.ById(customerId).ServiceRequests.ById(requestId).Get();

                if (request != null)
                    WriteObject(new PSServiceRequest(request));
            }
            finally
            {
                request = null;
            }
        }

        /// <summary>
        /// Gets a list of service requests for a customer.
        /// </summary>
        /// <param name="customerId">Identifier for the customer.</param>
        /// <param name="status">Identifier for the service request.</param>
        /// <param name="severity">Identifier for the service request.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="customerId"/> is empty or null.
        /// </exception>
        private void GetCustomerServiceRequests(string customerId, ServiceRequestStatus? status, ServiceRequestSeverity? severity)
        {
            ResourceCollection<ServiceRequest> requests;
            IEnumerable<ServiceRequest> results;

            customerId.AssertNotEmpty(nameof(customerId));

            try
            {
                requests = Partner.Customers.ById(customerId).ServiceRequests.Get();

                if (requests.TotalCount > 0)
                {
                    results = requests.Items;

                    if (status.HasValue)
                        results = results.Where(r => r.Status == status);

                    if (severity.HasValue)
                        results = results.Where(r => r.Severity == severity);

                    WriteObject(results.Select(r => new PSServiceRequest(r)), true);
                }
            }
            finally
            {
                requests = null;
                results = null;
            }
        }

        /// <summary>
        /// Gets the specified service request for a partner.
        /// </summary>
        /// <param name="requestId">Identifier for the service request.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="requestId"/> is empty or null.
        /// </exception>
        private void GetServiceRequest(string requestId)
        {
            ServiceRequest request;

            requestId.AssertNotEmpty(nameof(requestId));

            try
            {
                request = Partner.ServiceRequests.ById(requestId).Get();

                if (request != null)
                    WriteObject(new PSServiceRequest(request));
            }
            finally
            {
                request = null;
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
            IEnumerable<ServiceRequest> results;

            try
            {
                requests = Partner.ServiceRequests.Get();

                if (requests.TotalCount > 0)
                {
                    results = requests.Items;

                    if (status.HasValue)
                        results = results.Where(r => r.Status == status);

                    if (severity.HasValue)
                        results = results.Where(r => r.Severity == severity);

                    WriteObject(results.Select(r => new PSServiceRequest(r)), true);
                }
            }
            finally
            {
                requests = null;
                results = null;
            }
        }
    }
}