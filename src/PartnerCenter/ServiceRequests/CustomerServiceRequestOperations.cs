// -----------------------------------------------------------------------
// <copyright file="CustomerServiceRequestOperations.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Store.PartnerCenter.ServiceRequests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using Extensions;
    using Models.ServiceRequests;

    /// <summary>
    /// Implements operations that can be performed on a single customer's service requests.
    /// </summary>
    internal class CustomerServiceRequestOperations : BasePartnerComponent<Tuple<string, string>>, IServiceRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerServiceRequestOperations" /> class.
        /// </summary>
        /// <param name="rootPartnerOperations">The root partner operations instance.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="serviceRequestId">The service request identifier.</param>
        public CustomerServiceRequestOperations(IPartner rootPartnerOperations, string customerId, string serviceRequestId)
          : base(rootPartnerOperations, new Tuple<string, string>(customerId, serviceRequestId))
        {
            customerId.AssertNotEmpty(nameof(customerId));
            serviceRequestId.AssertNotEmpty(nameof(serviceRequestId));
        }

        /// <summary>
        /// Get the service request.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested service request.</returns>
        public ServiceRequest Get(CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => GetAsync(cancellationToken));
        }

        /// <summary>
        /// Get the service request.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The requested service request.</returns>
        public async Task<ServiceRequest> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Partner.ServiceClient.GetAsync<ServiceRequest>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.GetServiceRequestCustomer.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Updates the specified service request.
        /// </summary>
        /// <param name="entity">The service request to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service request that was just updated.</returns>
        public ServiceRequest Patch(ServiceRequest entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PartnerService.SynchronousExecute(() => PatchAsync(entity, cancellationToken));
        }

        /// <summary>
        /// Updates the specified service request.
        /// </summary>
        /// <param name="entity">The service request to be updated.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The service request that was just updated.</returns>
        public async Task<ServiceRequest> PatchAsync(ServiceRequest entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            entity.AssertNotNull(nameof(entity));

            return await Partner.ServiceClient.PatchAsync<ServiceRequest, ServiceRequest>(
                new Uri(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        $"/{PartnerService.Instance.ApiVersion}/{PartnerService.Instance.Configuration.Apis.UpdateServiceRequestCustomer.Path}",
                        Context.Item1, 
                        Context.Item2),
                    UriKind.Relative),
                entity,
                cancellationToken).ConfigureAwait(false);
        }
    }
}